using System.Globalization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sandwitch.Application.Helpers;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.ViewModels.Auth;

namespace Sandwitch.Application.Handlers;

/// <summary>
///     Represents a <see cref="BasicAuthenticationHandler" /> class. Inherits
///     <see cref="AuthenticationHandler{AuthenticationSchemeOptions}" />
/// </summary>
/// <param name="options">Injected <see cref="IOptionsMonitor{AuthenticationSchemeOptions}" /></param>
/// <param name="logger">Injected <see cref="ILoggerFactory" /></param>
/// <param name="encoder">Injected <see cref="UrlEncoder" /></param>
/// <param name="authManager">Injected <see cref="IAuthManager" /></param>
public class BasicAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IAuthManager authManager) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    /// <summary>
    ///     Gets Authentication Ticket
    /// </summary>
    /// <param name="authSignIn">Injected <see cref="AuthSignIn" /></param>
    /// <returns>Instance of <see cref="AuthenticationTicket" /></returns>
    private AuthenticationTicket GetAuthenticationTicket(AuthSignIn authSignIn)
    {
        List<Claim> @claims =
        [
            new(ClaimTypes.Name, authSignIn.Name),
            new(ClaimTypes.AuthenticationInstant, DateTime.Now.ToString()),
            new(ClaimTypes.Locality, CultureInfo.CurrentCulture.TwoLetterISOLanguageName),
            new(ClaimTypes.Version, Environment.OSVersion.VersionString),
            new(ClaimTypes.System, Environment.MachineName)
        ];

        return new AuthenticationTicket(
            new ClaimsPrincipal(new ClaimsIdentity(@claims,
                Scheme.Name)),
            Scheme.Name);
    }

    /// <summary>
    ///     Handles Authentication Asynchronously
    /// </summary>
    /// <returns>Instance of <see cref="AuthenticateResult" /></returns>
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Request.Headers.Authorization.Count == 0)
            return Task.FromResult(AuthenticateResult.Fail("Authorization Error. Header Not Found"));

        return authManager.CanAuthenticate(CredentialHelper.GetRequestCredentials(Request))
            ? Task.FromResult(
                AuthenticateResult.Success(GetAuthenticationTicket(CredentialHelper.GetRequestCredentials(Request))))
            : Task.FromResult(AuthenticateResult.Fail("Authorization Error. Authentication Error"));
    }
}