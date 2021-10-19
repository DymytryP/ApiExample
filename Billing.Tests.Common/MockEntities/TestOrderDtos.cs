using Billing.Infrastructure.Models;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders;
using System.Collections.Generic;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestOrderDtos
    {
        public static OrderDto OrderDto =
            new OrderDto
            {
                BillingUserId = 1,
                Description = "Test description",
                OrderNumber = "1111",
                OrderLines = new List<OrderLineDto>
                {
                    new OrderLineDto
                    {
                        Description = "Test product 22",
                        Name = "Product 22",
                        Price = 9.85m,
                        Quantity = 2
                    },
                    new OrderLineDto
                    {
                        Description = "Test product 23",
                        Name = "Product 23",
                        Price = 0.11m,
                        Quantity = 3
                    }
                },
                PayableAmount = new CurrencyAmount
                {
                    Amount = 20.03m,
                    Currency = Currency.EUR
                },
                PaymentProvider = "Visa",
            };
    }
}
