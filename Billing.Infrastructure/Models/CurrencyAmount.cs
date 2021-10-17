using Billing.Infrastructure.Models.Enums;

namespace Billing.Infrastructure.Models
{
    public class CurrencyAmount
    {
        public decimal Amount { get; set; }

        public Currency Currency { get; set; }
    }
}
