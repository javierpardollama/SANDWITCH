using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sandwitch.Domain.Settings;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="ConfigurationInstaller" /> class.
/// </summary>
public static class ConfigurationInstaller
{
    /// <summary>
    ///     Installs Api Settings
    /// </summary>
    /// <param name="builder">Injected <see cref="IHostApplicationBuilder" /></param>
    public static ApiSettings InstallApiSetttings(this IHostApplicationBuilder @builder)
    {
        var @jwtSettings = new ApiSettings();

        @builder.Configuration.GetSection("Api").Bind(@jwtSettings);
        @builder.Services.Configure<ApiSettings>(@builder.Configuration.GetSection("Api"));

        return @jwtSettings;
    }

    /// <summary>
    ///     Installs Rate Limit Settings
    /// </summary>
    /// <param name="builder">Injected <see cref="IHostApplicationBuilder" /></param>
    public static RateLimitSettings InstallRateLimitSettings(this IHostApplicationBuilder builder)
    {
        var @rateSettings = new RateLimitSettings();

        @builder.Configuration.GetSection("RateLimit").Bind(@rateSettings);
        @builder.Services.Configure<RateLimitSettings>(@builder.Configuration.GetSection("RateLimit"));

        return @rateSettings;
    }
}