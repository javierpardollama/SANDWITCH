namespace Sandwitch.Tier.ViewModels.Classes.Auth
{
    /// <summary>
    /// Represents a <see cref="AuthSignIn"/> class.
    /// </summary>
    public class AuthSignIn
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AuthSignIn"/>
        /// </summary>
        public AuthSignIn()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="UserName"/>
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="PassWord"/>
        /// </summary>
        public string PassWord { get; set; }
    }
}
