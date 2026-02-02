using Microsoft.Extensions.Options;
using Sandwitch.Domain.Managers;
using Sandwitch.Domain.Settings;

namespace Sandwitch.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="CredentialManager" /> class.  Inherits <see cref="BaseManager" />. Implements
///     <see cref="ICredentialManager" />.
/// </summary>
/// <param name="apiSettings">Injected <see cref="IOptions{ApiSettings}" /></param>
public class CredentialManager(IOptions<ApiSettings> apiSettings) : BaseManager(apiSettings), ICredentialManager
{
    /// <summary>
    ///     Checks wether Credentials are valid or not
    /// </summary>
    /// <param name="name">Injected <see cref="string" /></param>
    /// <param name="password">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="bool" /></returns>
    public bool CanAuthenticate(string @name, string @password)
    {
        bool @result = ApiSettings.Value.ApiLock == @name &&
                 ApiSettings.Value.ApiKey == @password;

        return @result;
    }
}