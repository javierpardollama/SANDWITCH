using System;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public class ViewHistorico : ViewBase
    {        
        public virtual ViewBandera Bandera { get; set; }

        public virtual ViewArenal Arenal { get; set; }
       
        public double Temperatura { get; set; }
      
        public DateTime BajaMarAlba { get; set; }
       
        public DateTime BajaMarOcaso { get; set; }
       
        public DateTime AltaMarAlba { get; set; }
      
        public DateTime AltaMarOcaso { get; set; }
    }
}
