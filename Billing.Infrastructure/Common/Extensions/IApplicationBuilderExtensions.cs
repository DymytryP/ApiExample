using Billing.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Billing.Infrastructure.Common.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Plugs-in global exception handling middleware.
        /// </summary>
        /// <param name="app">The application builder</param>
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
