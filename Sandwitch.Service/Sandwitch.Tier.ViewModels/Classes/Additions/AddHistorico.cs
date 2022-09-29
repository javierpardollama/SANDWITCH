using System;

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
        public int ArenalId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BanderaId"/>
        /// </summary>
        public int BanderaId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Temperatura"/>
        /// </summary>
        public double Temperatura { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarAlba"/>
        /// </summary>
        public TimeSpan BajaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="BajaMarOcaso"/>
        /// </summary>
        public TimeSpan BajaMarOcaso { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarAlba"/>
        /// </summary>
        public TimeSpan AltaMarAlba { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="AltaMarOcaso"/>
        /// </summary>
        public TimeSpan AltaMarOcaso { get; set; }
    }
}
