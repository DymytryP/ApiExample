using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataDistributor<TData, TDistributionResult>
    {
        /// <summary>
        /// Pushes data to data targets.
        /// </summary>
        /// <param name="data">The data to push.</param>
        /// <returns>The response</returns>
        Task<TDistributionResult> PushAsync(TData data);
    }
}
