namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewServiceException"/> class.
    /// </summary>
    public class ViewServiceException
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewServiceException"/>
        /// </summary>
        public ViewServiceException()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="StatusCode"/>
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Message"/>
        /// </summary>
        public string Message { get; set; }
    }
}
