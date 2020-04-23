using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewProvincia"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("provincia")]
    public class ViewProvincia : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewProvincia"/>
        /// </summary>
        public ViewProvincia()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Poblaciones"/>
        /// </summary>
        [XmlArray("poblaciones")]
        public virtual IList<ViewPoblacion> Poblaciones { get; set; }
    }
}
