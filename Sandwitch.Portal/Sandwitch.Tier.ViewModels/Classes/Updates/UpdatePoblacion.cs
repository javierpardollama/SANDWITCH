namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdatePoblacion"/> class. Inherits <see cref="UpdateBase"/>
    /// </summary>
    public class UpdatePoblacion : UpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdatePoblacion"/>
        /// </summary>
        public UpdatePoblacion()
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

        /// <summary>
        /// Gets or Sets <see cref="ProvinciaId"/>
        /// </summary>
        public int ProvinciaId { get; set; }
    }
}
