using Microsoft.AspNetCore.Builder;
using Sandwitch.Tier.ExceptionHandling.Middlewares;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ExceptionsConfiguration
    {
        public static void UseCustomExceptionMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
