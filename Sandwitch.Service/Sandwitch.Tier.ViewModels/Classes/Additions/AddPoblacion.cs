namespace Sandwitch.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddPoblacion"/> class.
    /// </summary>
    public class AddPoblacion
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AddPoblacion"/>
        /// </summary>
        public AddPoblacion()
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
