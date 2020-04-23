using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Bandera"/> class. Inherits <see cref="Base"/>
    /// </summary>
    public partial class Bandera : Base
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Bandera"/>
        /// </summary>
        public Bandera() { }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [Required]
        [ConcurrencyCheck]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [Required]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Historicos"/>
        /// </summary>
        public virtual IList<Historico> Historicos { get; set; }
    }
}
