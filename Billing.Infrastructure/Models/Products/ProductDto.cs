namespace Billing.Infrastructure.Models.Products
{
    public record ProductDto
    {
        public string Description { get; init; }

        public long Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }
    }
}
