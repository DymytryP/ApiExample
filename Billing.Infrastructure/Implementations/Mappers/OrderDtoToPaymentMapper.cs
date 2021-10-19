using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Payments;

namespace Billing.Infrastructure.Implementations.Mappers
{
    public class OrderDtoToPaymentMapper : IMapper<OrderDto, Payment>
    {
        /// <summary>
        /// Maps order DTO to payment.
        /// </summary>
        /// <param name="orderDto">Order DTO.</param>
        /// <returns>Payment.</returns>
        public Payment Map(OrderDto orderDto)
        {
            var payment = new Payment
            {
                BillingUserId = orderDto.BillingUserId,
                CurrencyAmount = orderDto.PayableAmount,
                OrderNumber = orderDto.OrderNumber
            };

            return payment;
        }
    }
}
