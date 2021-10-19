using Billing.Infrastructure.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    public abstract class PostController<TRequestData, TRequestProcessingResult> : ControllerBase
    {
        private readonly IRequestPipeline<TRequestData, TRequestProcessingResult> requestPipeline;

        private readonly AbstractValidator<TRequestData> requestValidationRules;

        public PostController(
            IRequestPipeline<TRequestData, TRequestProcessingResult> requestPipeline,
            AbstractValidator<TRequestData> requestValidationRules)
        {
            this.requestPipeline = requestPipeline ?? throw new ArgumentNullException(nameof(requestPipeline));
            this.requestValidationRules = requestValidationRules ?? throw new ArgumentNullException(nameof(requestValidationRules));
        }

        /// <summary>
        /// Processes request data.
        /// </summary>
        /// <param name="requestData">Request data object.</param>
        /// <returns>Result object as JSON.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Process(TRequestData requestData)
        {
            requestValidationRules.ValidateAndThrow(requestData);

            TRequestProcessingResult result = await requestPipeline.ProcessRequestAsync(requestData);

            return Ok(result);
        }

        /// <summary>
        /// Processes requests data.
        /// </summary>
        /// <param name="requestsData">Requests data object.</param>
        /// <returns>Result object as JSON.</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Process([FromBody] IEnumerable<TRequestData> requestsData)
        {
            foreach (TRequestData requestData in requestsData)
            {
                await requestValidationRules.ValidateAndThrowAsync(requestData);
            }

            IEnumerable<TRequestProcessingResult> result = await requestPipeline.ProcessRequestAsync(requestsData);

            return Ok(result);
        }
    }
}
