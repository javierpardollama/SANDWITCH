namespace Sandwitch.Domain.ViewModels.Auth;

/// <summary>
///     Represents a <see cref="AuthSignIn" /> class.
/// </summary>
public class AuthSignIn
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AuthSignIn" />
    /// </summary>
    public AuthSignIn()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="PassWord" />
    /// </summary>
    public string PassWord { get; set; }
}