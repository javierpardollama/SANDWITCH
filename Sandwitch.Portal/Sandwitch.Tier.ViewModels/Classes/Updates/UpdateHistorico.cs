using System;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    public class UpdateHistorico
    {
        public int Id { get; set; }

        public int ArenalId { get; set; }

        public int BanderaId { get; set; }

        public double Temperatura { get; set; }
       
        public DateTime BajaMarAlba { get; set; }
        
        public DateTime BajaMarOcaso { get; set; }
        
        public DateTime AltaMarAlba { get; set; }
        
        public DateTime AltaMarOcaso { get; set; }
    }
}
