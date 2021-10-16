using Billing.Infrastructure.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IPaymentGateway
    {
        /// <summary>
        /// Processes payment asynchronously.
        /// </summary>
        /// <param name="payment">The payment.</param>
        Task<IPaymentGatewayResponse> ProcessAsync(IPayment payment);

        /// <summary>
        /// Processes payments asynchronously.
        /// </summary>
        /// <param name="payment">The payment.</param>
        Task<IPaymentGatewayResponse> ProcessAsync(IEnumerable<IPayment> payment);
    }
}
