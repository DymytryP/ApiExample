namespace Billing.Infrastructure.Models.Orders.Receipts
{
    public record ReceiptLine
    {
        public string Name { get; init; }

        public decimal Price { get; init; }

        public int Quantity { get; init; }
    }
}
