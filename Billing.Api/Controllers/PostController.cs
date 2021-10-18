using Billing.Infrastructure.Contracts;
using Billing.Infrastructure.Contracts.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Api.Controllers
{
    public abstract class PostController<TRequestData, TRequestProcessingResult> : ControllerBase
        where TRequestData : IRequestData
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
        /// <returns>Result object as JSON</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Process(TRequestData requestData)
        {
            await this.requestValidationRules.ValidateAndThrowAsync(requestData);

            TRequestProcessingResult result = await this.requestPipeline.ProcessRequestAsync(requestData);

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

            IEnumerable<TRequestProcessingResult> result = await this.requestPipeline.ProcessRequestAsync(requestsData);

            return Ok(result);
        }
    }
}
