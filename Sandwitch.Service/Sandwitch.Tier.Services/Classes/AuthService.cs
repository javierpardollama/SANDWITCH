using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.Settings.Classes;
using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="AuthService"/> class.  Inherits <see cref="BaseService"/>. Implements <see cref="IAuthService"/>.
    /// </summary>   
    /// <param name="apiSettings">Injected <see cref="IOptions{ApiSettings}"/></param>
    public class AuthService(ILogger<AuthService> @logger,
                             IOptions<ApiSettings> @apiSettings) : BaseService(@apiSettings), IAuthService
    {

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
