using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Domain.Settings;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="RateLimiterInstaller" /> class.
/// </summary>
public static class RateLimiterInstaller
{
    /// <summary>
    ///     Extends Customized Rate Limit
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    /// <param name="RateSettings">Injected <see cref="RateLimitSettings" /></param>
    public static void InstallRateLimiter(this IServiceCollection @this, RateLimitSettings RateSettings)
    {
        @this.AddRateLimiter(_ => _
            .AddConcurrencyLimiter(RateSettings.PolicyName, options =>
            {
                options.PermitLimit = RateSettings.PermitLimit;
                options.QueueProcessingOrder = (QueueProcessingOrder)RateSettings.QueueProcessingOrder;
                options.QueueLimit = RateSettings.QueueLimit;
            }));
    }
}