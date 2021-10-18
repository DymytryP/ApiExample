using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataProvider<TParameter, TData>
    {
        /// <summary>
        /// Gets data.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The data.</returns>
        TData Get(TParameter parameter);

        /// <summary>
        /// Gets data asychronously.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The data.</returns>
        Task<TData> GetAsync(TParameter parameter);
    }
}
