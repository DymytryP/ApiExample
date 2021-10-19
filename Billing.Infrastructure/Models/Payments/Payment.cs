namespace Billing.Infrastructure.Models.Payments
{
    public record Payment
    {
        public long BillingUserId { get; init; }

        public CurrencyAmount CurrencyAmount { get; init; }

        public string OrderNumber { get; init; }
    }
}
