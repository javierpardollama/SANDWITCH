using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Sandwitch.Application.ViewModels.Auth;

namespace Sandwitch.Application.Helpers;

/// <summary>
///     Represents a <see cref="CredentialHelper" /> class.
/// </summary>
public static class CredentialHelper
{
    /// <summary>
    ///     Gets Request Credentials
    /// </summary>
    /// <param name="request">Injected <see cref="HttpRequest" /></param>
    /// <returns>Instance of <see cref="AuthSignIn" /></returns>
    public static AuthSignIn GetRequestCredentials(HttpRequest request)
    {
        var authenticationHeader = AuthenticationHeaderValue.Parse(request.Headers.Authorization);

        var encoded = Convert.FromBase64String(authenticationHeader.Parameter!);

        var decoded = Encoding.UTF8.GetString(encoded).Split([':'], 2);

        return new AuthSignIn
        {
            Name = decoded[0],
            PassWord = decoded[1]
        };
    }
}