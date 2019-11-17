using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Arenal : Base
    {
        public Arenal() { }

        [Required]
        [ConcurrencyCheck]
        public string Name { get; set; }

        public virtual IList<ArenalPoblacion> ArenalPoblaciones { get; set; }

        public virtual IList<Historico> Historicos { get; set; }
    }
}
