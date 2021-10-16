using Billing.Infrastructure.Contracts.Models;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IRequestPipeline<TRequestData> where TRequestData : IRequestData
    {
        Task<IRequestDataProcessingResult> ProcessRequestAsync(TRequestData requestData);
    }
}
