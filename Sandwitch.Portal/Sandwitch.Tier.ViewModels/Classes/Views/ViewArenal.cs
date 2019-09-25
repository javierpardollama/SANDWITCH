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

        public virtual IList<ViewHistorico> Historicos { get; set; }

        public virtual ViewHistorico LastHistorico => Historicos?.AsQueryable().OrderBy(x => x.LastModified.Date).Last();

        public virtual IList<ViewArenalPoblacion> ArenalPoblaciones { get; set; }

        public virtual IList<ViewPoblacion> Poblaciones => ArenalPoblaciones?.AsQueryable().Select(x => x.Poblacion).ToList();
    }
}
