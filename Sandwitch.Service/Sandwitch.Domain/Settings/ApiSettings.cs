namespace Sandwitch.Domain.Settings;

/// <summary>
///     Represents a <see cref="ApiSettings" /> class
/// </summary>
public class ApiSettings
{
    /// <summary>
    ///     Gets or Sets <see cref="Http" />
    /// </summary>
    public Settings Http { get; set; }
    
    /// <summary>
    ///     Gets or Sets <see cref="Mcp" />
    /// </summary>
    public Settings Mcp { get; set; }
}

/// <summary>
///     Represents a <see cref="Settings" /> class
/// </summary>
public class Settings
{
    /// <summary>
    ///     Gets or Sets <see cref="User" />
    /// </summary>
    public string User { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Password" />
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Audiences" />
    /// </summary>
    public IList<string> Audiences { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Issuer" />
    /// </summary>
    public string Issuer { get; set; }
}