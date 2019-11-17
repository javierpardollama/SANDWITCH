using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public partial class Bandera : Base
    {
        public Bandera() { }

        [Required]
        [ConcurrencyCheck]
        public string Name { get; set; }

        [Required]
        public string ImageUri { get; set; }

        public virtual IList<Historico> Historicos { get; set; }
    }
}
