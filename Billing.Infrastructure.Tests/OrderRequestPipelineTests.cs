using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Implementations;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Orders.Receipts;
using Billing.Infrastructure.Models.Orders.RequestData;
using Billing.Infrastructure.Models.Products;
using Billing.Tests.Common.MockEntities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Tests
{
    public class Tests
    { 
        private Mock<IMapper<(OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products), OrderDto>> orderRequestDataToOrderMapperMock;
        private Mock<IMapper<(OrderDto OrderDto, BillingUserDto BillingUserDto), Receipt>> dataToReceiptMapperMock;
        private Mock<ILogger<OrderRequestPipeline>> loggerMock;
        private Mock<IDataDistributor<OrderDto, OrderDistributionResult>> orderDataDistributorMock;
        private Mock<IDataAggregator<OrderRequestData, (IEnumerable<ProductDto> Products, BillingUserDto User)>> productUserDataAggregatorMock;

        private OrderRequestPipeline orderRequestPipeline;

        [SetUp]
        public void Setup()
        {
            // Arrange
            orderRequestDataToOrderMapperMock = new();
            dataToReceiptMapperMock = new();
            loggerMock = new();
            orderDataDistributorMock = new();
            productUserDataAggregatorMock = new();

            orderRequestPipeline = new(
                productUserDataAggregatorMock.Object,
                orderRequestDataToOrderMapperMock.Object,
                orderDataDistributorMock.Object,
                dataToReceiptMapperMock.Object,
                loggerMock.Object);

            var orderProducts = (TestOrderRequestDatas.OrderRequestData, TestProductDtos.ProductDtos);
            orderRequestDataToOrderMapperMock
                .Setup(mock => mock.Map(orderProducts))
                .Returns(TestOrderDtos.OrderDto);

            var orderDtoBillingUser = (TestOrderDtos.OrderDto, TestBillingUserDtos.BillingUserDto_UserId1);
            dataToReceiptMapperMock
                .Setup(mock => mock.Map(orderDtoBillingUser))
                .Returns(TestReceipts.Receipt);

            orderDataDistributorMock
                .Setup(mock => mock.PushAsync(TestOrderDtos.OrderDto))
                .ReturnsAsync(TestOrderDistributionResults.OrderDistributionResult);

            productUserDataAggregatorMock
                .Setup(mock => mock.AggregateAsync(TestOrderRequestDatas.OrderRequestData))
                .ReturnsAsync((TestProductDtos.ProductDtos, TestBillingUserDtos.BillingUserDto_UserId1));

        }

        [Test]
        public async Task OrderRequestPipeline_ProcessRequestAsync_When_CorrectOrderRequestData_Then_ReturnsReceipt()
        {
            // Act
            Receipt receipt = await orderRequestPipeline.ProcessRequestAsync(TestOrderRequestDatas.OrderRequestData);

            // Assert
            Assert.That(receipt.CurrencyAmount.Amount, Is.EqualTo(20.03m));
            Assert.That(receipt.Requisites.Name, Is.EqualTo("Test user"));
            Assert.That(receipt.ReceiptLines.Count, Is.EqualTo(2));
        }
    }
}