using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    [XmlRoot("arenal-poblacion")]
    public class ViewArenalPoblacion : ViewBase
    {
        public ViewArenalPoblacion()
        {
        }

        [XmlElement("arenal")]
        public ViewArenal Arenal { get; set; }

        [XmlElement("poblacion")]
        public ViewPoblacion Poblacion { get; set; }
    }
}
