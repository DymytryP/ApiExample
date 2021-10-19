using Billing.Infrastructure.Models.Carts;
using Billing.Infrastructure.Models.Orders.RequestData;
using System.Collections.Generic;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestOrderRequestDatas
    {
        public static OrderRequestData OrderRequestData =
            new OrderRequestData
            {
                BillingUserId = 1,
                CartItems = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductId = 22,
                        Quantity = 2
                    },
                    new CartItem
                    {
                        ProductId = 23,
                        Quantity = 3
                    }
                },
                Description = "Test description",
                OrderNumber = "1111",
                PayableAmount = TestCurrencyAmounts.CurrencyAmount,
                PaymentProvider = "Visa"
            };
    }
}
