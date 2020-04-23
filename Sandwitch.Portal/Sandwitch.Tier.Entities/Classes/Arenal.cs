using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Arenal"/> class. Inherits <see cref="Base"/>
    /// </summary>
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
        [ConcurrencyCheck]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ArenalPoblaciones"/>
        /// </summary>
        public virtual IList<ArenalPoblacion> ArenalPoblaciones { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Historicos"/>
        /// </summary>
        public virtual IList<Historico> Historicos { get; set; }
    }
}
