namespace Billing.Infrastructure.Configuration
{
    public class BillingApiConfiguration : IBillingApiConfiguration
    {
        public int MaximumCartItemsCount { get; set; }

        public decimal MaximumOrderAmount { get; set; }

        public int MaximumProductsQuantity { get; set; }

        public int MinimumCartItemsCount { get; set; }

        public decimal MinimumOrderAmount { get; set; }

        public int MinimumProductsQuantity { get; set; }

        public int ProductsApiTimeOut { get; set; }

        public string ProductsApiUrl { get; set; }
    }
}
