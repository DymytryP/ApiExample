using Billing.Infrastructure.Contracts.Models;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IRequestPipeline<TRequestData, TRequestProcessingResult> where TRequestData : IRequestData
    {
        /// <summary>
        /// Processes request data model asynchronously.
        /// </summary>
        /// <param name="requestData">The request data model.</param>
        /// <returns>The processing result model.</returns>
        Task<TRequestProcessingResult> ProcessRequestAsync(TRequestData requestData);
    }
}
