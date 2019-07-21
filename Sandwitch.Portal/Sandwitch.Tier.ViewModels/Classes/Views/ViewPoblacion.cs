using System.Collections.Generic;
using System.Linq;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewPoblacion : ViewBase
    {
        public ViewPoblacion()
        {
        }

        public string Name { get; set; }

        public string ImageUri { get; set; }

        public ViewProvincia Provincia { get; set; }

        public virtual ICollection<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        public virtual ICollection<ViewArenal> Arenales => ArenalPoblaciones?.AsQueryable().Select(x => x.Arenal).ToList();
    }
}
