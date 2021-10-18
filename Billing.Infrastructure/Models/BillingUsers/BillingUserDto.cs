namespace Billing.Infrastructure.Models.BillingUsers
{
    public record BillingUserDto
    {
        public string Code { get; init; }

        public string Name { get; init; }
    }
}
