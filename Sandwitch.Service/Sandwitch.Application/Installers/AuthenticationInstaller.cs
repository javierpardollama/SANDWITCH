using System.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Application.Handlers;
using Sandwitch.Domain.Settings;

namespace Sandwitch.Application.Installers;

/// <summary>
///     Represents a <see cref="AuthenticationInstaller" /> class.
/// </summary>
public static class AuthenticationInstaller
{
    /// <summary>
    ///     Installs Authentication
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    /// <param name="settings">Injected <see cref="ApiSettings" /></param>
    public static void InstallAuthentication(this IServiceCollection @this, ApiSettings @settings)
    {
        @this.AddAuthentication(nameof(AuthenticationSchemes.Basic))
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(nameof(AuthenticationSchemes.Basic),
                options => options.ClaimsIssuer = @settings.ApiIssuer);
    }
}