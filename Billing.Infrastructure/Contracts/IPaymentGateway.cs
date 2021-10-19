using Billing.Infrastructure.Models.Enums;
using Billing.Infrastructure.Models.Payments;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IPaymentGateway
    {
        /// <summary>
        /// Processes payment asynchronously.
        /// </summary>
        /// <param name="payment">The payment.</param>
        Task<PaymentGatewayResponse> ProcessAsync(Payment payment);
    }
}
