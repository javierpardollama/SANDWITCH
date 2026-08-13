using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sandwitch.Domain.Settings;
using Sandwitch.Application.Handlers.Authentication;
using Sandwitch.Application.Options;
using Sandwitch.Application.Options.Authentication;

namespace Sandwitch.Application.Installers;

/// <summary>
///     Represents a <see cref="IdentificationInstaller" /> class.
/// </summary>
public static class IdentificationInstaller
{
    /// <summary>
    ///     Installs Authentication
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    /// <param name="settings">Injected <see cref="ApiSettings" /></param>
    public static void InstallIdentification(this IServiceCollection @this, ApiSettings @settings)
    {
        @this.AddAuthentication(nameof(AuthenticationSchemes.Basic))
            .AddScheme<BasicAuthenticationSchemeOptions, BasicAuthenticationHandler>("HttpApi",
                options =>
                {
                    options.ClaimsIssuer = @settings.Http.Issuer;
                    options.User = settings.Http.User;
                    options.Password = settings.Http.Password;
                })
            .AddScheme<BasicAuthenticationSchemeOptions, BasicAuthenticationHandler>("McpApi",
                options =>
                {
                    options.ClaimsIssuer = @settings.Mcp.Issuer;
                    options.User = settings.Mcp.User;
                    options.Password = settings.Mcp.Password;
                });
        
        @this.AddAuthorization(options =>
        {
            options.AddPolicy("HttpApi", policy =>
            {
                policy.AddAuthenticationSchemes("HttpApi");
                policy.RequireAuthenticatedUser();
            });

            options.AddPolicy("McpApi", policy =>
            {
                policy.AddAuthenticationSchemes("McpApi");
                policy.RequireAuthenticatedUser();
            });
        });
    }

    /// <summary>
    ///     Uses Identification
    /// </summary>
    /// <param name="this">Injected <see cref="WebApplication" /></param>
    public static void UseIdentification(this WebApplication @this)
    {
        @this.UseAuthentication();
        @this.UseAuthorization();
    }
}