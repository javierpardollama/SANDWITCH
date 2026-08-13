namespace Sandwitch.Domain.Managers;

/// <summary>
///     Represents a <see cref="ICredentialManager" /> interface. Inherits <see cref="IBaseManager" />
/// </summary>
public interface ICredentialManager : IBaseManager
{
    /// <summary>
    ///     Checks wether Credentials are valid or not
    /// </summary>
    /// <param name="user">Injected <see cref="string" /></param>
    /// <param name="password">Injected <see cref="string" /></param>
    /// <param name="scheme">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="bool" /></returns>
    public bool CanAuthenticate(string @user, string @password, string @scheme);
}