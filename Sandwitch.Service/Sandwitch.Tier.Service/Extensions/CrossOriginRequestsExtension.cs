using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Sandwitch.Tier.Settings.Classes;

namespace Sandwitch.Tier.Service.Extensions
{
    /// <summary>
    /// Represents a <see cref="CrossOriginRequestsExtension"/> class.
    /// </summary>
    public static class CrossOriginRequestsExtension
    {
        /// <summary>
        /// Seeds Customized Origins
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="ApiSettings">Injected <see cref="ApiSettings"/></param>
        public static void AddCustomizedCrossOriginRequests(this IServiceCollection @this, ApiSettings ApiSettings)
        {
            @this.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins(ApiSettings.ApiAudiences.ToArray())
                                                                  .AllowCredentials()
                                                                  .AllowAnyMethod()
                                                                  .AllowAnyHeader();
                    });

            });

        }
    }
}
