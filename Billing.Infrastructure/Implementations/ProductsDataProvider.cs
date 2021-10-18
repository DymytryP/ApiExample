using Billing.Infrastructure.Common.Exceptions;
using Billing.Infrastructure.Configuration;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Products;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class ProductsDataProvider : RestClient, IDataProvider<IEnumerable<long>, IEnumerable<ProductDto>>
    {
        private readonly IBillingApiConfiguration billingApiConfiguration;

        public ProductsDataProvider(
            IBillingApiConfiguration billingApiConfiguration) : base(billingApiConfiguration.ProductsApiUrl)
        {
            this.billingApiConfiguration = billingApiConfiguration
                ?? throw new ArgumentNullException(nameof(billingApiConfiguration));
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public IEnumerable<ProductDto> Get(IEnumerable<long> productId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets enumerable of products.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDto>> GetAsync(IEnumerable<long> productIds)
        {
            base.Timeout = billingApiConfiguration.ProductsApiTimeOut;
            var request = new RestRequest(Method.GET);

            var response = await ExecuteAsync<IEnumerable<ProductDto>>(request);

            var result = response.IsSuccessful
                ? response.Data
                : throw new FailedToReceiveDataFromProductsApiException();

            return result;
        }
    }
}
