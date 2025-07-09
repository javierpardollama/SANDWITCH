using Sandwitch.Domain.ViewModels.Auth;

namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="IAuthManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface IAuthManager : IBaseManager
{
    /// <summary>
    ///     Checks wether Credentials are valid or not
    /// </summary>
    /// <param name="authSignIn">Injected <see cref="AuthSignIn" /></param>
    /// <returns>Instance of <see cref="bool" /></returns>
    public bool CanAuthenticate(AuthSignIn authSignIn);
}