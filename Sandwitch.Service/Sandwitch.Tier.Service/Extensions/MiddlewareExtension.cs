using Microsoft.AspNetCore.Builder;

using Sandwitch.Tier.Middlewares.Middlewares;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="MiddlewareExtension"/> class.
    /// </summary>
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Extends Customized Exception MiddleWare
        /// </summary>
        /// <param name="this">Injected <see cref="WebApplication"/></param>
        public static void UseCustomizedMiddlewares(this WebApplication @this)
        {
            @this.UseMiddleware<HeaderMiddleware>();

            // Add other services here
        }
    }
}
