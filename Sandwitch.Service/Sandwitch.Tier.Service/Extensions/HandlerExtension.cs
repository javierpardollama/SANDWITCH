using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Tier.Exceptions.Handlers;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="HandlerExtension"/> class.
    /// </summary>
    public static class HandlerExtension
    {
        /// <summary>
        /// Extends Customized Handlers
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        public static void AddCustomizedHandlers(this IServiceCollection @this)
        {
            @this.AddExceptionHandler<ProblemDetailsExceptionHandler>();
        }

    }
}
