using Billing.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    public class PostController<TRequestData> : ControllerBase
    {
        private readonly IDataRequestPipeline<TRequestData> requestPipeline;

        public PostController(IDataRequestPipeline<TRequestData> requestPipeline)
        {
            this.requestPipeline = requestPipeline;
        }

        /// <summary>
        /// Processes request.
        /// </summary>
        /// <param name="requestData">Request data object.</param>
        /// <returns>JSON </returns>
        [Route("{action}")]
        [HttpPost]
        public async Task<IActionResult> Process(TRequestData requestData)
        {

            var result = await requestPipeline.ProcessRequestAsync(requestData);

            return Ok(result);
        }
    }
}
