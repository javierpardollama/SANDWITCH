using Microsoft.AspNetCore.Builder;

using Sandwitch.Tier.ExceptionHandling.Middlewares;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ExceptionsExtension
    {
        public static void UseCustomizedExceptionMiddlewares(this IApplicationBuilder @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();

            // Add other services here
        }
    }
}
