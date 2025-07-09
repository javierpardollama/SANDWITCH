using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Domain.Settings;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="CorsInstaller" /> class.
/// </summary>
public static class CorsInstaller
{
    /// <summary>
    ///     Installs Cors
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    /// <param name="ApiSettings">Injected <see cref="ApiSettings" /></param>
    public static void InstallCors(this IServiceCollection @this, ApiSettings ApiSettings)
    {
        @this.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins([.. ApiSettings.ApiAudiences])
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .Build();
            });
        });
    }
}