using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.BillingUsers;
using Billing.Infrastructure.Models.Orders.RequestData;
using Billing.Infrastructure.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class OrderDataAggregator : IDataAggregator<OrderRequestData, (IEnumerable<ProductDto> Products, BillingUserDto User)>
    {
        private readonly IDataProvider<long, BillingUserDto> billingUserDataProvider;

        private readonly IDataProvider<IEnumerable<long>, IEnumerable<ProductDto>> productDataProvider;

        public OrderDataAggregator(
            IDataProvider<long, BillingUserDto> billingUserDataProvider,
            IDataProvider<IEnumerable<long>, IEnumerable<ProductDto>> productDataProvider)
        {
            this.billingUserDataProvider = billingUserDataProvider
                ?? throw new ArgumentNullException(nameof(billingUserDataProvider));
            this.productDataProvider = productDataProvider ?? throw new ArgumentNullException(nameof(productDataProvider));
        }

        /// <summary>
        /// Aggregates products and user data.
        /// </summary>
        /// <param name="orderRequestData">The order request data.</param>
        /// <returns>Products and user.</returns>
        public async Task<(IEnumerable<ProductDto> Products, BillingUserDto User)> AggregateAsync(OrderRequestData orderRequestData)
        {
            BillingUserDto billingUser = await billingUserDataProvider.GetAsync(orderRequestData.BillingUserId);

            IEnumerable<long> productIds = orderRequestData.CartItems
                .Select(ci => ci.ProductId);
            IEnumerable<ProductDto> products = await productDataProvider.GetAsync(productIds);

            return (products, billingUser);
        }
    }
}
