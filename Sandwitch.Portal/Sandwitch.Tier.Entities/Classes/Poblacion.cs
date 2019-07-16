using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Poblacion : Base
    {
        public Poblacion() { }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUri { get; set; }

        [Required]
        public Provincia Provincia { get; set; }

        public virtual ICollection<ArenalPoblacion> ArenalPoblaciones { get; set; }
    }
}
