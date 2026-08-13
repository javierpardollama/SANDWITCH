using Microsoft.AspNetCore.Authentication;

namespace Sandwitch.Application.Options.Authentication;

/// <summary>
///     Represents a <see cref="BasicAuthenticationSchemeOptions" /> class. Inherits <see cref="AuthenticationSchemeOptions"/>
/// </summary>
public class BasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    /// <summary>
    /// Gets or Sets <see cref="User"/>
    /// </summary>
    public string User { get; set; }
    /// <summary>
    /// Gets or Sets <see cref="Password"/>
    /// </summary>
    public string Password { get; set; }
}