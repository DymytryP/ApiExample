using Billing.Infrastructure.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Tests.Common.MockEntities
{
    public static class TestProductDtos
    {
        public static IEnumerable<ProductDto> ProductDtos =
            new List<ProductDto>
            {
                new ProductDto
                {
                    Description = "Test product 22",
                    Id = 22,
                    Name = "Product 22",
                    Price = 9.85m
                },
                new ProductDto
                {
                    Description = "Test product 23",
                    Id = 23,
                    Name = "Product 23",
                    Price = 0.11m
                }
            }
            .AsEnumerable();
    }
}
