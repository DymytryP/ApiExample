using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Payments;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations.PaymentGateways
{
    public abstract class PaymentGateway : IPaymentGateway, IDataTarget<Payment>
    {
        private readonly ILogger<PaymentGateway> logger;

        public PaymentGateway(ILogger<PaymentGateway> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Processes payment asynchronously.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <returns>Payment gateway response.</returns>
        public virtual async Task<PaymentGatewayResponse> ProcessAsync(Payment payment)
        {
            payment = payment ?? throw new ArgumentNullException(nameof(payment));

            Random rng = new Random();
            PaymentGatewayResponse paymentGatewayResponse = PaymentGatewayResponse.Success;
            try
            {
                await Task.Run(() => Thread.Sleep(rng.Next(11, 37)));
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to process payment for order: {payment.OrderNumber}", ex);
                paymentGatewayResponse = PaymentGatewayResponse.Failure;
            }

            return paymentGatewayResponse;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void Receive(Payment payment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Receives payment asynchronously.
        /// </summary>
        /// <param name="payment">The payment</param>
        public async Task ReceiveAsync(Payment payment)
        {
            await ProcessAsync(payment);
        }
    }
}
