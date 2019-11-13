using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    [XmlRoot("poblacion")]
    public class ViewPoblacion : ViewBase
    {
        public ViewPoblacion()
        {
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        [XmlElement("provincia")]
        public ViewProvincia Provincia { get; set; }

        [XmlArray("arenal-poblaciones")]
        public virtual IList<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        [XmlArray("arenales")]
        public virtual IList<ViewArenal> Arenales => ArenalPoblaciones?.AsQueryable().Select(x => x.Arenal).ToList();
    }
}
