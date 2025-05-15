using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateArenal"/> class. Inherits <see cref="UpdateBase"/>
    /// </summary>
    public class UpdateArenal : UpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateArenal"/>
        /// </summary>
        public UpdateArenal()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="PoblacionesId"/>
        /// </summary>
        [Required]
        public virtual IList<int> PoblacionesId { get; set; }
    }
}
