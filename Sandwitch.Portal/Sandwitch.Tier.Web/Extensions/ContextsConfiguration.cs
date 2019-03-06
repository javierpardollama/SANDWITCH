using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Contexts.Interfaces;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ContextsConfiguration
    {
        public static void AddCustomContexts(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();

            // Add other services here
        }        
    }
}
