using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewProvincia : ViewBase
    {
        public ViewProvincia()
        {
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        [XmlElement("poblaciones")]
        public virtual IList<ViewPoblacion> Poblaciones { get; set; }
    }
}
