using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewArenalPoblacion"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("arenal-poblacion")]
    public class ViewArenalPoblacion : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewArenalPoblacion"/>
        /// </summary>
        public ViewArenalPoblacion()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Arenal"/>
        /// </summary>
        [XmlElement("arenal")]
        public ViewArenal Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Poblacion"/>
        /// </summary>
        [XmlElement("poblacion")]
        public ViewPoblacion Poblacion { get; set; }
    }
}
