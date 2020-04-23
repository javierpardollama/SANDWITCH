using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="ArenalPoblacion"/> class. Inherits <see cref="Base"/>
    /// </summary>
    public partial class ArenalPoblacion : Base
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ArenalPoblacion"/>
        /// </summary>
        public ArenalPoblacion() { }

        /// <summary>
        /// Gets or Sets <see cref="Arenal"/>
        /// </summary>
        [Required]
        public Arenal Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Poblacion"/>
        /// </summary>
        [Required]
        public Poblacion Poblacion { get; set; }
    }
}
