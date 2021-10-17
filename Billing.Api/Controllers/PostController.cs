using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Contracts.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    public abstract class PostController<TRequestData> : ControllerBase where TRequestData : IRequestData
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
        /// Processes request data.
        /// </summary>
        /// <param name="requestData">Request data object.</param>
        /// <returns>Result object as JSON</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Process(TRequestData requestData)
        {
            await this.requestValidationRules.ValidateAndThrowAsync(requestData);

            var result = await this.requestPipeline.ProcessRequestAsync(requestData);

            return Ok(result);
        }

        /// <summary>
        /// Processes requests data.
        /// </summary>
        /// <param name="requestsData">Requests data object.</param>
        /// <returns>Result object as JSON</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Process(IEnumerable<TRequestData> requestsData)
        {
            foreach (TRequestData requestData in requestsData)
            {
                await this.requestValidationRules.ValidateAndThrowAsync(requestData);
            }

            var result = await this.requestPipeline.ProcessRequestAsync(requestsData);

            return Ok(result);
        }
    }
}
