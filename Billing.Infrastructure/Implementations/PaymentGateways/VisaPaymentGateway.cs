using Microsoft.Extensions.Logging;

namespace Billing.Infrastructure.Implementations.PaymentGateways
{
    public class VisaPaymentGateway : PaymentGateway
    {
        public VisaPaymentGateway(ILogger<PaymentGateway> logger) : base(logger)
        {
        }
    }
}
