using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Provincia"/> class. Inherits <see cref="Base"/>
    /// </summary>
    [Index(nameof(Name))]
    public partial class Provincia : Base
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Provincia"/>
        /// </summary>
        public Provincia() { }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [Required]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Poblaciones"/>
        /// </summary>
        public virtual IList<Poblacion> Poblaciones { get; set; }
    }
}
