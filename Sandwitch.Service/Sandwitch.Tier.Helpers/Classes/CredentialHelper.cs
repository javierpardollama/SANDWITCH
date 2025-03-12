using Microsoft.AspNetCore.Http;
using Sandwitch.Tier.ViewModels.Classes.Auth;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace Sandwitch.Tier.Helpers.Classes
{
    /// <summary>
    /// Represents a <see cref="CredentialHelper"/> class.
    /// </summary>
    public static class CredentialHelper
    {
        /// <summary>
        /// Gets Request Credentials
        /// </summary>
        /// <param name="request">Injected <see cref="HttpRequest"/></param>
        /// <returns>Instance of <see cref="AuthSignIn"/></returns>
        public static AuthSignIn GetRequestCredentials(HttpRequest @request)
        {
            AuthenticationHeaderValue @authenticationHeader = AuthenticationHeaderValue.Parse(@request.Headers.Authorization);

            byte[] @encoded = Convert.FromBase64String(@authenticationHeader.Parameter);

            string[] @decoded = Encoding.UTF8.GetString(@encoded).Split([':'], 2);

            return new AuthSignIn
            {
                UserName = @decoded[0],
                PassWord = @decoded[1]
            };
        }
    }
}
