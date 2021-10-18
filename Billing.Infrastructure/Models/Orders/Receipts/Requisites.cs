namespace Billing.Infrastructure.Models.Orders.Receipts
{
    public record Requisites
    {
        public string Code { get; set; }

        public string Name { get; init; }
    }
}
