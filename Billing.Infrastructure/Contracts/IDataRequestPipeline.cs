using Billing.Infrastructure.Contracts.Models;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IDataRequestPipeline<TRequestData>
    {
        Task<IRequestDataProcessingResult> ProcessRequestAsync(TRequestData requestData);
    }
}
