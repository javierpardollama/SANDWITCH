using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewViento"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("viento")]
    public class ViewViento : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewViento"/>
        /// </summary>
        public ViewViento()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Historicos"/>
        /// </summary>
        [XmlArray("historicos")]
        public virtual IList<ViewHistorico> Historicos { get; set; }
    }
}
