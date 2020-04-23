using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewArenal"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("arenal")]
    public class ViewArenal : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewArenal"/>
        /// </summary>
        public ViewArenal()
        {
        }

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

        /// <summary>
        /// Gets or Sets <see cref="LastHistorico"/>
        /// </summary>
        [XmlElement("last-historico")]
        public virtual ViewHistorico LastHistorico => Historicos?.AsQueryable().OrderBy(x => x.LastModified.Date).Last();

        /// <summary>
        /// Gets or Sets <see cref="ArenalPoblaciones"/>
        /// </summary>
        [XmlArray("arenal-poblaciones")]
        public virtual IList<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Poblaciones"/>
        /// </summary>
        [XmlArray("poblaciones")]
        public virtual IList<ViewPoblacion> Poblaciones => ArenalPoblaciones?.AsQueryable().Select(x => x.Poblacion).ToList();
    }
}
