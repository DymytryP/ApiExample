using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Contracts
{
    public interface IRequestPipeline<TRequestData, TRequestProcessingResult>
    {
        /// <summary>
        /// Processes request data model asynchronously.
        /// </summary>
        /// <param name="requestData">The request data model.</param>
        /// <returns>The processing result model.</returns>
        Task<TRequestProcessingResult> ProcessRequestAsync(TRequestData requestData);

        /// <summary>
        /// Processes request data models asynchronously.
        /// </summary>
        /// <param name="requestData">The request data models.</param>
        /// <returns>The processing result models.</returns>
        Task<IEnumerable<TRequestProcessingResult>> ProcessRequestAsync(IEnumerable<TRequestData> requestData);
    }
}
