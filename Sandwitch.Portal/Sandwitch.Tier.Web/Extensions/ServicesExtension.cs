using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Services.Classes;
using Sandwitch.Tier.Services.Interfaces;

namespace Sandwitch.Tier.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void AddCustomizedServices(this IServiceCollection services)
        {
            services.AddTransient<IProvinciaService, ProvinciaService>();
            services.AddTransient<IPoblacionService, PoblacionService>();
            services.AddTransient<IBanderaService, BanderaService>();
            services.AddTransient<IArenalService, ArenalService>();
            services.AddTransient<IHistoricoService, HistoricoService>();

            // Add other services here
        }
    }
}
