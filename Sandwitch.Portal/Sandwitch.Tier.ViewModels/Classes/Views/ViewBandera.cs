using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewBandera : ViewBase
    {
        public string ImageUri { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ViewHistorico> Historicos { get; set; }
    }
}
