using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void AddCustomizedServices(this IServiceCollection @this)
        {
            @this.AddTransient<IProvinciaService, ProvinciaService>();
            @this.AddTransient<IPoblacionService, PoblacionService>();
            @this.AddTransient<IBanderaService, BanderaService>();
            @this.AddTransient<IArenalService, ArenalService>();
            @this.AddTransient<IHistoricoService, HistoricoService>();

            // Add other services here
        }
    }
}
