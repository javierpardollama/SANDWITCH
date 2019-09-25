using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewProvincia : ViewBase
    {
        public ViewProvincia()
        {
        }

        public string Name { get; set; }

        public string ImageUri { get; set; }

        public virtual IList<ViewPoblacion> Poblaciones { get; set; }
    }
}
