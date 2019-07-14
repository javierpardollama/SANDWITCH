using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Provincia : Base
    {
        public Provincia() { }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUri { get; set; }

        public virtual ICollection<Poblacion> Poblaciones { get; set; }
    }
}
