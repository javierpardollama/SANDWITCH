using System;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddHistorico"/> class.
    /// </summary>
    public class AddHistorico
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AddHistorico"/>
        /// </summary>
        public AddHistorico()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ArenalId"/>
        /// </summary>
        [Required]
        public int ArenalId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BanderaId"/>
        /// </summary>
        [Required]
        public int BanderaId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="VientoId"/>
        /// </summary>
        [Required]
        public int VientoId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Velocidad"/>
        /// </summary>
        [Required]
        public double Velocidad { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Temperatura"/>
        /// </summary>
        [Required]
        public double Temperatura { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarAlba"/>
        /// </summary>
        [Required]
        public TimeSpan BajaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarOcaso"/>
        /// </summary>
        [Required]
        public TimeSpan BajaMarOcaso { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarAlba"/>
        /// </summary>
        [Required]
        public TimeSpan AltaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarOcaso"/>
        /// </summary>
        [Required]
        public TimeSpan AltaMarOcaso { get; set; }
    }
}
