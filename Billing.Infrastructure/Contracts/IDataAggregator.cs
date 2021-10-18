using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataAggregator<TParameter, TData>
    {
        /// <summary>
        /// Aggregates data into single model.
        /// </summary>
        /// <param name="parameter">The parameter for aggregation</param>
        /// <returns>Data as single object.</returns>
        Task<TData> AggregateAsync(TParameter parameter);
    }
}
