
using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Contexts.Classes;
using Sandwitch.Tier.Contexts.Interfaces;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="ContextsExtension"/> class.
    /// </summary>
    public static class ContextsExtension
    {
        /// <summary>
        /// Extends Customized Contexts
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        public static void AddCustomizedContexts(this IServiceCollection @this)
        {
            @this.AddScoped<IApplicationContext, ApplicationContext>();

            // Add other services here
        }
    }
}
