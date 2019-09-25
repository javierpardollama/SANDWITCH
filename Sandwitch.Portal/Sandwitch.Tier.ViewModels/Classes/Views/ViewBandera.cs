using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewBandera : ViewBase
    {
        public ViewBandera()
        {
        }

        public string ImageUri { get; set; }

        public string Name { get; set; }

        public virtual IList<ViewHistorico> Historicos { get; set; }
    }
}
