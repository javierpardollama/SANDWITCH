namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewException"/> class.
    /// </summary>
    public class ViewException
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewException"/>
        /// </summary>
        public ViewException()
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
