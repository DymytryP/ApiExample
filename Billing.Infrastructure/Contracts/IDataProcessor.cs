using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataProcessor<TInput, TOutput>
    {
        Task<TOutput> ProcessDataAsync(TInput requestData);
    }
}
