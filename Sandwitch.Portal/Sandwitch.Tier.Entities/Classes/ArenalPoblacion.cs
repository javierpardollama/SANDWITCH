using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public class ArenalPoblacion : Base
    {
        public ArenalPoblacion() { }

        [Required]
        public Arenal Arenal { get; set; }

        [Required]
        public Poblacion Poblacion { get; set; }
    }
}
