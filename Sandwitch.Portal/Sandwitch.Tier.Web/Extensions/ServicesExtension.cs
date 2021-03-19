using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Web.Extensions
{
    /// <summary>
    /// Represents a <see cref="ServicesExtension"/> class.
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Extends Customized Services
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        public static void AddCustomizedServices(this IServiceCollection @this)
        {
            @this.AddTransient<IProvinciaService, ProvinciaService>();
            @this.AddTransient<IPoblacionService, PoblacionService>();
            @this.AddTransient<IBanderaService, BanderaService>();
            @this.AddTransient<IArenalService, ArenalService>();
            @this.AddTransient<IHistoricoService, HistoricoService>();

            @this.AddTransient<IAuthService, AuthService>();
            // Add other services here
        }
    }
}
