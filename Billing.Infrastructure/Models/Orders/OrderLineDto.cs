namespace Billing.Infrastructure.Models.Orders
{
    public record OrderLineDto
    {
        public string Description { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public int Quantity { get; init; }
    }
}
