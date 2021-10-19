using Billing.Data.Models;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Orders.Receipts;
using Billing.Infrastructure.Models.Orders.RequestData;
using Billing.Infrastructure.Models.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class OrderRequestPipeline : IRequestPipeline<OrderRequestData, Receipt>
    {
        private readonly IMapper<(OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products), OrderDto> orderRequestDataToOrderMapper;

        private readonly IMapper<(OrderDto OrderDto, BillingUserDto BillingUserDto), Receipt> dataToReceiptMapper;

        private readonly ILogger<OrderRequestPipeline> logger;

        private readonly IDataDistributor<OrderDto, OrderDistributionResult> orderDataDistributor;

        private readonly IDataAggregator<OrderRequestData, (IEnumerable<ProductDto> Products, BillingUserDto User)> productUserDataAggregator;

        public OrderRequestPipeline(
            IDataAggregator<OrderRequestData, (IEnumerable<ProductDto> Products, BillingUserDto User)> productUserDataAggregator,
            IMapper<(OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products), OrderDto> orderRequestDataToOrderMapper,
            IDataDistributor<OrderDto, OrderDistributionResult> orderDataDistributor,
            IMapper<(OrderDto OrderDto, BillingUserDto BillingUserDto), Receipt> dataToReceiptMapper,
            ILogger<OrderRequestPipeline> logger)
        {
            this.productUserDataAggregator = productUserDataAggregator ?? throw new ArgumentNullException(nameof(productUserDataAggregator));
            this.orderRequestDataToOrderMapper = orderRequestDataToOrderMapper ?? throw new ArgumentNullException(nameof(orderRequestDataToOrderMapper));
            this.orderDataDistributor = orderDataDistributor ?? throw new ArgumentNullException(nameof(orderDataDistributor));
            this.dataToReceiptMapper = dataToReceiptMapper ?? throw new ArgumentNullException(nameof(dataToReceiptMapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Processes order asynchronously.
        /// </summary>
        /// <param name="requestData">The request data model.</param>
        /// <returns>The processing result model.</returns>
        public async Task<Receipt> ProcessRequestAsync(OrderRequestData requestData)
        {
            (IEnumerable<ProductDto> products, BillingUserDto billingUser) = await productUserDataAggregator.AggregateAsync(requestData);

            OrderDto order = orderRequestDataToOrderMapper.Map((requestData, products));

            var dataDistributionResult = await orderDataDistributor.PushAsync(order);

            if (dataDistributionResult.DatabaseSaveOperationResult == DatabaseSaveOperationResult.Failure)
            {
                logger.LogError($"Error while saving order: {requestData.OrderNumber} to database.");
            }

            Receipt receipt = null;
            if (dataDistributionResult.PaymentResponseType == PaymentGatewayResponse.Success)
            {
                receipt = dataToReceiptMapper.Map((order, billingUser));
            }

            return receipt 
                ?? throw new Exception($"Error encountered while processing order: {requestData.OrderNumber}.");
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public async Task<IEnumerable<Receipt>> ProcessRequestAsync(IEnumerable<OrderRequestData> requestData)
        {
            throw new NotImplementedException();
        }
    }
}
