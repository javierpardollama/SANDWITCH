using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Settings.Classes;

using System.Linq;

namespace Sandwitch.Tier.Service.Extensions
{
    public static class CrossOriginsExtension
    {
        /// <summary>
        /// Seeds Customized Origins
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="ApiSettings">Injected <see cref="ApiSettings"/></param>
        public static void AddCustomizedOrigins(this IServiceCollection @this, ApiSettings ApiSettings)
        {
            @this.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(ApiSettings.Clients.ToArray())
                                                                  .AllowCredentials()
                                                                  .AllowAnyMethod()
                                                                  .AllowAnyHeader();
                    });

            });

        }
    }
}
