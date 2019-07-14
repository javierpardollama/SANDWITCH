using System;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Historico : Base
    {
        public Historico() { }

        [Required]
        public virtual Bandera Bandera { get; set; }

        [Required]
        public virtual Arenal Arenal { get; set; }

        [Required]
        public double Temperatura { get; set; }

        [Required]
        public DateTime BajaMarAlba { get; set; }

        [Required]
        public DateTime BajaMarOcaso { get; set; }

        [Required]
        public DateTime AltaMarAlba { get; set; }

        [Required]
        public DateTime AltaMarOcaso { get; set; }
    }
}
