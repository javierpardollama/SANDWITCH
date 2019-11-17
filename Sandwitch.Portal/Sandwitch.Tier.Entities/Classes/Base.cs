using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Sandwitch.Tier.Entities.Interfaces;

namespace Sandwitch.Tier.Entities.Classes
{
    public abstract class Base : IBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ConcurrencyCheck]
        public int Id { get; set; }

        [Required]
        [ConcurrencyCheck]
        public DateTime LastModified { get; set; }

        [Required]
        [ConcurrencyCheck]
        public bool Deleted { get; set; }
    }
}
