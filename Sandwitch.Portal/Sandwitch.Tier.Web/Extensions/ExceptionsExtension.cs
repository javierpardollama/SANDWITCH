using Microsoft.AspNetCore.Builder;

using Sandwitch.Tier.ExceptionHandling.Middlewares;

namespace Sandwitch.Tier.Web.Extensions
{
    /// <summary>
    /// Represents a <see cref="ExceptionsExtension"/> class.
    /// </summary>
    public static class ExceptionsExtension
    {
        /// <summary>
        /// Extends Customized Exception MiddleWare
        /// </summary>
        /// <param name="this">Injected <see cref="IApplicationBuilder"/></param>
        public static void UseCustomizedExceptionMiddlewares(this IApplicationBuilder @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();

            // Add other services here
        }
    }
}
