namespace Billing.Infrastructure.Configuration
{
    public interface IBillingApiConfiguration
    {
        public int MaximumCartItemsCount { get; }

        public decimal MaximumOrderAmount { get; }

        public int MaximumProductsQuantity { get; }

        public int MinimumCartItemsCount { get; }

        public decimal MinimumOrderAmount { get; }

        public int MinimumProductsQuantity { get; }

        public int ProductsApiTimeOut { get; }

        public string ProductsApiUrl { get; }
    }
}
