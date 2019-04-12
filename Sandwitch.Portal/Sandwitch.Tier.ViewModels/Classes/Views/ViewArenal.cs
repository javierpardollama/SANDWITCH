using System.Collections.Generic;
using System.Linq;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewArenal : ViewBase
    {       
        public string Name { get; set; }

        public virtual ICollection<ViewHistorico> Historicos { get; set; }

        public virtual ViewHistorico LastHistorico {
            get
            {
                return this.Historicos?.AsQueryable().OrderBy(x=>x.LastModified.Date).Last();
            }
        }

        public virtual ICollection<ViewArenalPoblacion> Poblaciones { get; set; }
    }
}
