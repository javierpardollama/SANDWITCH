using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    [XmlRoot("bandera")]
    public class ViewBandera : ViewBase
    {
        public ViewBandera()
        {
        }

        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("historicos")]
        public virtual IList<ViewHistorico> Historicos { get; set; }
    }
}
