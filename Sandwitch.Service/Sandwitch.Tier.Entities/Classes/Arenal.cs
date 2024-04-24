using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Arenal"/> class. Inherits <see cref="Base"/>
    /// </summary>
    [Index(nameof(Name))]
    public partial class Arenal : Base
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Arenal"/>
        /// </summary>
        public Arenal() { }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ArenalPoblaciones"/>
        /// </summary>
        public virtual ICollection<ArenalPoblacion> ArenalPoblaciones { get; set; } = [];

        /// <summary>
        /// Gets or Sets <see cref="Historicos"/>
        /// </summary>
        public virtual ICollection<Historico> Historicos { get; set; } = [];
    }
}
