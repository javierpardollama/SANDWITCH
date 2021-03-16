using Microsoft.Extensions.Options;

using Sandwitch.Tier.Authentication.Interfaces;
using Sandwitch.Tier.Settings.Classes;
using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Authentication.Classes
{
    /// <summary>
    /// Represents a <see cref="AuthenticationService"/> class. Implements <see cref="IAuthenticationService"/>
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Instance of <see cref="IOptions{ApiSettings}"/>
        /// </summary>
        private readonly IOptions<ApiSettings> ApiSettings;

        /// <summary>
        /// Initializes a new Instance of <see cref="AuthenticationService"/>
        /// </summary>
        /// <param name="apiSettings">Injected <see cref="IOptions{ApiSettings}"/></param>
        public AuthenticationService(IOptions<ApiSettings> @apiSettings)
        {
            ApiSettings = @apiSettings;
        }

        /// <summary>
        /// Checks wether Credentials are valid or not
        /// </summary>
        /// <param name="authSignIn">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="bool"/></returns>
        public bool CanAuthenticate(AuthSignIn @authSignIn)
        {
            bool @result = false;

            if (ApiSettings.Value.ApiLock.Equals(@authSignIn.UserName) && ApiSettings.Value.ApiKey.Equals(@authSignIn.PassWord))
            {
                @result = true;
            }

            return @result;
        }
    }
}
