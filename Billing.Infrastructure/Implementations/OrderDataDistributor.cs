using Billing.Data.Models;
using Billing.Data.Models.Entities;
using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Orders;
using Billing.Infrastructure.Models.Payments;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations
{
    public class OrderDataDistributor : IDataDistributor<OrderDto, OrderDistributionResult>
    {
        private ILogger<OrderDataDistributor> logger;

        private readonly IDataTarget<Order> orderRepository;

        private readonly IMapper<OrderDto, Order> orderDtoToOrderMapper;

        private readonly IMapper<OrderDto, Payment> orderDtoToPaymentMapper;

        private readonly Func<PaymentProvider, IDataTarget<Payment>> paymentDataTargetFactory;


        public OrderDataDistributor(
            IMapper<OrderDto, Payment> orderDtoToPaymentMapper,
            IMapper<OrderDto, Order> orderDtoToOrderMapper,
            IDataTarget<Order> orderRepository,
            Func<PaymentProvider, IDataTarget<Payment>> paymentDataTargetFactory,
            ILogger<OrderDataDistributor> logger)
        {
            this.orderDtoToPaymentMapper = orderDtoToPaymentMapper ?? throw new ArgumentNullException(nameof(orderDtoToPaymentMapper));
            this.orderDtoToOrderMapper = orderDtoToOrderMapper ?? throw new ArgumentNullException(nameof(orderDtoToOrderMapper));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this.paymentDataTargetFactory = paymentDataTargetFactory ?? throw new ArgumentNullException(nameof(paymentDataTargetFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Pushes order data to targets asynchronously.
        /// </summary>
        /// <param name="data">The order</param>
        /// <returns></returns>
        public async Task<OrderDistributionResult> PushAsync(OrderDto orderDto)
        {
            Order order = orderDtoToOrderMapper.Map(orderDto);

            OrderDistributionResult orderDistributionResult = new OrderDistributionResult
            {
                DatabaseSaveOperationResult = DatabaseSaveOperationResult.Success,
                PaymentResponseType = PaymentGatewayResponse.Success
            };

            try
            {
                await orderRepository.ReceiveAsync(order);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                orderDistributionResult.DatabaseSaveOperationResult = DatabaseSaveOperationResult.Failure;
            }

            Payment payment = orderDtoToPaymentMapper.Map(orderDto);

            PaymentProvider paymentProvider = Enum.GetValues<PaymentProvider>()
                .Where(paymentProvider => paymentProvider.ToString() == orderDto.PaymentProvider)
                .First();
            IDataTarget<Payment> paymentGateway = paymentDataTargetFactory(paymentProvider);

            try
            {
                await paymentGateway.ReceiveAsync(payment);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                orderDistributionResult.PaymentResponseType = PaymentGatewayResponse.Failure;
            }

            return orderDistributionResult;
        }
    }
}
