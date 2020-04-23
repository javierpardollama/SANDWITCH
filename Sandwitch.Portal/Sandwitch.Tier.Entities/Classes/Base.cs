using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Sandwitch.Tier.Entities.Interfaces;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Base"/> class. Implements <see cref="IBase"/>
    /// </summary>
    public abstract class Base : IBase
    {
        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [ConcurrencyCheck]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [Required]
        [ConcurrencyCheck]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Deleted"/>
        /// </summary>
        [Required]
        [ConcurrencyCheck]
        public bool Deleted { get; set; }
    }
}
