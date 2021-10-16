using Billing.Infrastructure.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Billing.Infrastructure.Middleware
{
    /// <summary>
    /// The exception handling middleware class. Provides global exception handling for running host.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Plug-in the middleware's functionality into request processing pipeline.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception caught: {ex.Message}", ex);
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles exceptions at global level.
        /// </summary>
        /// <param name="context">The http context.</param>
        /// <param name="exception">Exception caught.</param>
        private Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            string message = "Internal server error.";

            message = exception is ValidationException
                ? string.Join(
                    Environment.NewLine,
                    (exception as ValidationException).Errors
                        .Select(e => e.ErrorMessage))
                : exception is BusinessException
                    ? exception.Message
                    : message;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(
                    new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = message
                    }));
        }
    }
}
