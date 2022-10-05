using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IAuthService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IAuthService : IBaseService
    {
        /// <summary>
        /// Checks wether Credentials are valid or not
        /// </summary>
        /// <param name="authSignIn">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="bool"/></returns>
        bool CanAuthenticate(AuthSignIn @authSignIn);
    }
}
