using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Arenal : Base
    {
        public Arenal() { }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ArenalPoblacion> Poblaciones { get; set; }

        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
