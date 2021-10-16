using Billing.Infrastructure.Contracts.Models;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IPaymentGateway
    {
        /// <summary>
        /// Processes the payment asynchronously.
        /// </summary>
        /// <param name="payment">The payment.</param>
        Task<IPaymentGatewayResponse> PushPaymentAsync(IPayment payment);
    }
}
