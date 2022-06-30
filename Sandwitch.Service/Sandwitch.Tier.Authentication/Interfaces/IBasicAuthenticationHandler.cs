using Microsoft.AspNetCore.Authentication;

using Sandwitch.Tier.ViewModels.Classes.Auth;

namespace Sandwitch.Tier.Authentication.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IBasicAuthenticationHandler"/> interface.
    /// </summary>
    public interface IBasicAuthenticationHandler
    {
        /// <summary>
        /// Gets Authentication Ticket
        /// </summary>
        /// <param name="authSignIn">Injected <see cref="AuthSignIn"/></param>
        /// <returns>Instance of <see cref="AuthenticationTicket"/></returns>
        AuthenticationTicket GetAuthenticationTicket(AuthSignIn @authSign);
    }
}
