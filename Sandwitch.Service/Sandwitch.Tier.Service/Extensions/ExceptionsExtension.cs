using Microsoft.AspNetCore.Builder;

using Sandwitch.Tier.ExceptionHandling.Middlewares;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="ExceptionsExtension"/> class.
    /// </summary>
    public static class ExceptionsExtension
    {
        /// <summary>
        /// Extends Customized Exception MiddleWare
        /// </summary>
        /// <param name="this">Injected <see cref="WebApplication"/></param>
        public static void UseCustomizedExceptionMiddlewares(this WebApplication @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();

            // Add other services here
        }
    }
}
