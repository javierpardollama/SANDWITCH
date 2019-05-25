using Microsoft.AspNetCore.Builder;
using Sandwitch.Tier.GlobalErrorHandling;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ExceptionsConfiguration
    {
        public static void AddCustomExceptionMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
