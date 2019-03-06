using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public class Poblacion : Base
    {
        public Poblacion() { }

        [Required]
        public string Name { get; set; }

        [Required]
        public Provincia Provincia { get; set; }

        public virtual ICollection<ArenalPoblacion> Arenales { get; set; }
    }
}
