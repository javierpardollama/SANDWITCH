using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewPoblacion"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("poblacion")]
    public class ViewPoblacion : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewPoblacion"/>
        /// </summary>
        public ViewPoblacion()
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
        /// Gets or Sets <see cref="Provincia"/>
        /// </summary>
        [XmlElement("provincia")]
        public ViewProvincia Provincia { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ArenalPoblaciones"/>
        /// </summary>
        [XmlArray("arenal-poblaciones")]
        public virtual IList<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Arenales"/>
        /// </summary>
        [XmlArray("arenales")]
        public virtual IList<ViewArenal> Arenales => ArenalPoblaciones?.AsQueryable().Select(x => x.Arenal).ToList();
    }
}
