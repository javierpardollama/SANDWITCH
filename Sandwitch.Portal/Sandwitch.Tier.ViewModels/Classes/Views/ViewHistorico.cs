using System;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewHistorico : ViewBase
    {
        public ViewHistorico()
        {
        }

        [XmlElement("bandera")]
        public virtual ViewBandera Bandera { get; set; }

        [XmlElement("arenal")]
        public virtual ViewArenal Arenal { get; set; }

        [XmlElement("temperatura")]
        public double Temperatura { get; set; }

        [XmlElement("baja-mar-alba")]
        public DateTime BajaMarAlba { get; set; }

        [XmlElement("baja-mar-ocaso")]
        public DateTime BajaMarOcaso { get; set; }

        [XmlElement("alta-mar-alba")]
        public DateTime AltaMarAlba { get; set; }

        [XmlElement("alta-mar-ocaso")]
        public DateTime AltaMarOcaso { get; set; }
    }
}
