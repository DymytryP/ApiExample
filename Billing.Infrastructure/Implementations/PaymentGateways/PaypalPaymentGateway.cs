using Microsoft.Extensions.Logging;

namespace Billing.Infrastructure.Implementations.PaymentGateways
{
    public class PaypalPaymentGateway : PaymentGateway
    {
        public PaypalPaymentGateway(ILogger<PaymentGateway> logger) : base(logger)
        {
        }
    }
}
