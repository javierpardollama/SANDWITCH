using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public class Bandera : Base
    {
        public Bandera() { }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUri { get; set; }

        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
