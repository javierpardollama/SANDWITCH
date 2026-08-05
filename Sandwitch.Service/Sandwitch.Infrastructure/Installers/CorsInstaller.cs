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
    /// <param name="settings">Injected <see cref="ApiSettings" /></param>
    public static void InstallCors(this IServiceCollection @this, ApiSettings @settings)
    {
        @this.AddCors(options =>
        {
            options.AddPolicy("HttpApi",policy =>
            {
                policy.WithOrigins([.. @settings.Http.Audiences])
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .Build();
            });
            
            options.AddPolicy("McpApi",policy =>
            {
                policy.WithOrigins([.. @settings.Mcp.Audiences])
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .Build();
            });
        });
    }
}