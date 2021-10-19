using Billing.Infrastructure.Models.Orders.Receipts;
using System.Collections.Generic;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestReceipts
    {
        public static Receipt Receipt =
            new Receipt
            {
                CreatedOn = TestDateTimes.Now,
                CurrencyAmount = TestCurrencyAmounts.CurrencyAmount,
                OrderNumber = "1111",
                ReceiptLines = new List<ReceiptLine>
                {
                    new ReceiptLine
                    {
                        Name = "Product 22",
                        Price = 9.85m,
                        Quantity = 2
                    },
                    new ReceiptLine
                    {
                        Name = "Product 23",
                        Price = 0.11m,
                        Quantity = 3
                    }
                },
                Requisites = new Requisites
                {
                    Code = "000000-00000",
                    Name = "Test user"
                }
            };
    }
}
