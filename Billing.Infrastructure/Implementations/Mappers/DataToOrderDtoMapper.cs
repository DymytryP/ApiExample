using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Orders.RequestData;
using Billing.Infrastructure.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace Billing.Infrastructure.Implementations.Mappers
{
    public class DataToOrderDtoMapper : IMapper<(OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products), OrderDto>
    {
        /// <summary>
        /// Maps order request data and billing user DTO to order DTO.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public OrderDto Map((OrderRequestData OrderRequestData, IEnumerable<ProductDto> Products) orderRequestAndProductsData)
        {
            var order = new OrderDto
            {
                BillingUserId = orderRequestAndProductsData.OrderRequestData.BillingUserId,
                Description = orderRequestAndProductsData.OrderRequestData.Description,
                OrderNumber = orderRequestAndProductsData.OrderRequestData.OrderNumber,
                PayableAmount = orderRequestAndProductsData.OrderRequestData.PayableAmount,
                PaymentProvider = orderRequestAndProductsData.OrderRequestData.PaymentProvider,
                OrderLines = orderRequestAndProductsData.OrderRequestData.CartItems
                    .Join(
                        orderRequestAndProductsData.Products,
                        cartItem => cartItem.ProductId,
                        product => product.Id,
                        (cartItem, product) => new OrderLineDto
                            {
                                Description = product.Description,
                                Name = product.Name,
                                Price = product.Price,
                                Quantity = cartItem.Quantity
                            })
                    .ToList()
            };

            return order;
        }
    }
}
