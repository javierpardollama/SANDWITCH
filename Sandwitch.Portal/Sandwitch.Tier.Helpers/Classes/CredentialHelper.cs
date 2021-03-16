using System;
using System.Net.Http.Headers;
using System.Text;

using Microsoft.AspNetCore.Http;

using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Helpers.Classes
{
    public static class CredentialHelper
    {
        public static AuthSignIn GetRequestCredentials(HttpRequest @request)
        {
            AuthenticationHeaderValue @authenticationHeader = AuthenticationHeaderValue.Parse(@request.Headers["Authorization"]);

            byte[] @encoded = Convert.FromBase64String(@authenticationHeader.Parameter);

            string[] @decoded = Encoding.UTF8.GetString(@encoded).Split(new[] { ':' }, 2);

            return new AuthSignIn
            {
                UserName = @decoded[0],
                PassWord = @decoded[1]
            };
        }
    }
}
