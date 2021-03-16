
using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Authentication.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IAuthenticationService"/> interface.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Checks wether Credentials are valid or not
        /// </summary>
        /// <param name="authSignIn">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="bool"/></returns>
        bool CanAuthenticate(AuthSignIn @authSignIn);
    }
}
