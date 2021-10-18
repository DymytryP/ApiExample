namespace Billing.Infrastructure.Models.BillingUsers
{
    public record BillingUser
    {
        public string Code { get; init; }

        public long Id { get; init; }

        public string Name { get; init; }
    }
}
