namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateProvincia"/> class. Inherits <see cref="UpdateBase"/>
    /// </summary>
    public class UpdateProvincia : UpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateProvincia"/>
        /// </summary>
        public UpdateProvincia()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        public string ImageUri { get; set; }
    }
}
