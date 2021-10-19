using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Models.Payments;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Implementations.PaymentGateways
{
    public class MasterCardPaymentGateway : PaymentGateway, IDataTarget<Payment>
    {
        public MasterCardPaymentGateway(ILogger<PaymentGateway> logger) : base(logger)
        {
        }
    }
}
