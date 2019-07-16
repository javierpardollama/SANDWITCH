using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewPoblacion : ViewBase
    {
        public string Name { get; set; }

        public string ImageUri { get; set; }

        public ViewProvincia Provincia { get; set; }

        public virtual ICollection<ViewArenalPoblacion> ArenalPoblaciones { get; set; }
    }
}
