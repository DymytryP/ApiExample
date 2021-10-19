namespace Billing.Infrastructure.Models.Carts
{
    public record CartItem
    {
        public long ProductId { get; init; }

        public int Quantity { get; init; }
    }
}
