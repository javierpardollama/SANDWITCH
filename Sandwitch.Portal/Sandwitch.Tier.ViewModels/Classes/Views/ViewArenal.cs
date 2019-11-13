using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    [XmlRoot("arenal")]
    public class ViewArenal : ViewBase
    {
        public ViewArenal()
        {
        }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlArray("historicos")]
        public virtual IList<ViewHistorico> Historicos { get; set; }

        [XmlElement("last-historico")]
        public virtual ViewHistorico LastHistorico => Historicos?.AsQueryable().OrderBy(x => x.LastModified.Date).Last();

        [XmlArray("arenal-poblaciones")]
        public virtual IList<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        [XmlArray("poblaciones")]
        public virtual IList<ViewPoblacion> Poblaciones => ArenalPoblaciones?.AsQueryable().Select(x => x.Poblacion).ToList();
    }
}
