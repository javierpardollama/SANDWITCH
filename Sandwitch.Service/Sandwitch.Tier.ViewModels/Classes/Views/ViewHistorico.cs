using System;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewHistorico"/> class. Inherits <see cref="ViewBase"/>
    /// </summary>
    [XmlRoot("historico")]
    public class ViewHistorico : ViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewHistorico"/>
        /// </summary>
        public ViewHistorico()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Viento"/>
        /// </summary>
        [XmlElement("viento")]
        public virtual ViewViento Viento { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Bandera"/>
        /// </summary>
        [XmlElement("bandera")]
        public virtual ViewBandera Bandera { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Arenal"/>
        /// </summary>
        [XmlElement("arenal")]
        public virtual ViewArenal Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Velocidad"/>
        /// </summary>
        [XmlElement("velocidad")]
        public double Velocidad { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Temperatura"/>
        /// </summary>
        [XmlElement("temperatura")]
        public double Temperatura { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarAlba"/>
        /// </summary>
        [XmlElement("baja-mar-alba")]
        public TimeSpan BajaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarOcaso"/>
        /// </summary>
        [XmlElement("baja-mar-ocaso")]
        public TimeSpan BajaMarOcaso { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarAlba"/>
        /// </summary>
        [XmlElement("alta-mar-alba")]
        public TimeSpan AltaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarOcaso"/>
        /// </summary>
        [XmlElement("alta-mar-ocaso")]
        public TimeSpan AltaMarOcaso { get; set; }
    }
}
