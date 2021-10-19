using Billing.Infrastructure.Models;
using Billing.Infrastructure.Models.Enums;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestCurrencyAmounts
    {
        public static CurrencyAmount CurrencyAmount =
            new CurrencyAmount
            {
                Amount = 20.03m,
                Currency = Currency.EUR
            };
    }
}
