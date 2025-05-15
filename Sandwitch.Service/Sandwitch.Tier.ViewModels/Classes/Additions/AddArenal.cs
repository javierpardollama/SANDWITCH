using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddArenal"/> class.
    /// </summary>
    public class AddArenal
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AddArenal"/>
        /// </summary>
        public AddArenal()
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
