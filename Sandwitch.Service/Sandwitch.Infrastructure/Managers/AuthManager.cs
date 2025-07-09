using Microsoft.Extensions.Options;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Settings;
using Sandwitch.Domain.ViewModels.Auth;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="AuthManager" /> class.  Inherits <see cref="BaseManager" />. Implements
///     <see cref="IAuthManager" />.
/// </summary>
/// <param name="apiSettings">Injected <see cref="IOptions{ApiSettings}" /></param>
public class AuthManager(IOptions<ApiSettings> apiSettings) : BaseManager(apiSettings), IAuthManager
{
    /// <summary>
    ///     Checks wether Credentials are valid or not
    /// </summary>
    /// <param name="authSignIn">Injected <see cref="AuthSignIn" /></param>
    /// <returns>Instance of <see cref="bool" /></returns>
    public bool CanAuthenticate(AuthSignIn authSignIn)
    {
        var result = false;

        if (ApiSettings.Value.ApiLock.Equals(authSignIn.UserName) &&
            ApiSettings.Value.ApiKey.Equals(authSignIn.PassWord)) result = true;

        return result;
    }
}