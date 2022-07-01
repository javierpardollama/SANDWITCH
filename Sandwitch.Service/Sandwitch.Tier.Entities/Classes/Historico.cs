using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Historico"/> class. Inherits <see cref="Base"/>
    /// </summary>
    public partial class Historico : Base
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Historico"/>
        /// </summary>
        public Historico() { }

        /// <summary>
        /// Gets or Sets <see cref="Bandera"/>
        /// </summary>
        [Required]
        public virtual Bandera Bandera { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Arenal"/>
        /// </summary>
        [Required]
        public virtual Arenal Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Temperatura"/>
        /// </summary>
        [Required]
        public double Temperatura { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarAlba"/>
        /// </summary>
        [Required]
        public DateTime BajaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarOcaso"/>
        /// </summary>
        [Required]
        public DateTime BajaMarOcaso { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarAlba"/>
        /// </summary>
        [Required]
        public DateTime AltaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarOcaso"/>
        /// </summary>
        [Required]
        public DateTime AltaMarOcaso { get; set; }
    }
}
