using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public class Historico : Base
    {
        public Historico() { }

        [Required]
        public virtual Bandera Bandera { get; set; }

        [Required]
        public virtual Arenal Arenal { get; set; }

        [Required]
        public double Temperatura { get; set; }
    }
}
