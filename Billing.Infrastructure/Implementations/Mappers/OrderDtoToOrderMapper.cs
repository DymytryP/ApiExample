using Billing.Data.Models.Entities;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Orders;

namespace Billing.Infrastructure.Implementations.Mappers
{
    public class OrderDtoToOrderMapper : IMapper<OrderDto, Order>
    {
        /// <summary>
        /// Maps order DTO to order.
        /// </summary>
        /// <param name="orderDto">Order DTO</param>
        /// <returns>Order.</returns>
        public Order Map(OrderDto orderDto)
        {
            var order = new Order
            {
                Amount = orderDto.PayableAmount.Amount,
                BillingUserId = orderDto.BillingUserId,
                Currency = orderDto.PayableAmount.Currency.ToString(),
                Description = orderDto.Description,
                OrderNumber = orderDto.OrderNumber
            };

            return order;
        }
    }
}
