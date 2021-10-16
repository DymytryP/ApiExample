using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Contracts.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    public class PostController<TRequestData> : ControllerBase where TRequestData : IRequestData
    {
        private readonly IRequestPipeline<TRequestData> requestPipeline;

        private readonly AbstractValidator<TRequestData> requestValidationRules;

        public PostController(
            IRequestPipeline<TRequestData> requestPipeline,
            AbstractValidator<TRequestData> requestValidationRules)
        {
            this.requestPipeline = requestPipeline;
            this.requestValidationRules = requestValidationRules;
        }

        /// <summary>
        /// Processes request.
        /// </summary>
        /// <param name="requestData">Request data object.</param>
        /// <returns>Result object as JSON</returns>
        [Route("{action}")]
        [HttpPost]
        public async Task<IActionResult> Process(TRequestData requestData)
        {
            await this.requestValidationRules.ValidateAndThrowAsync(requestData);

            var result = await this.requestPipeline.ProcessRequestAsync(requestData);

            return Ok(result);
        }
    }
}
