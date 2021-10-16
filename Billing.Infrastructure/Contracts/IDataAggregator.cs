using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataAggregator<TParameter, TData>
    {
        Task<TData> AggregateAsync(TParameter parameter);
    }
}
