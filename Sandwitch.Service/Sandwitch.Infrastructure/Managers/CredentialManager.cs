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
    /// <param name="user">Injected <see cref="string" /></param>
    /// <param name="password">Injected <see cref="string" /></param>
    /// <param name="scheme">Injected <see cref="string" /></param>
    /// <returns>Instance of <see cref="bool" /></returns>
    public bool CanAuthenticate(string @user, string @password, string @scheme)
    {
        var @result = @scheme switch
        {
            "https" => ApiSettings.Value.Http is { User: var u, Password: var p } && u == @user && p == @password,
            "mcp" => ApiSettings.Value.Mcp is { User: var u, Password: var p } && u == @user && p == @password,
            _ => false
        };
       
        return @result;
    }
}