using System.Collections.Generic;
using System.Linq;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewArenal : ViewBase
    {
        public ViewArenal()
        {
        }

        public string Name { get; set; }

        public virtual ICollection<ViewHistorico> Historicos { get; set; }

        public virtual ViewHistorico LastHistorico => Historicos?.AsQueryable().OrderBy(x => x.LastModified.Date).Last();

        public virtual ICollection<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        public virtual ICollection<ViewPoblacion> Poblaciones => ArenalPoblaciones?.AsQueryable().Select(x => x.Poblacion).ToList();
    }
}
