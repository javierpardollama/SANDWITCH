﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Provincia"/> class. Inherits <see cref="Base"/>
    /// </summary>
    [Index(nameof(Name), [nameof(Deleted)])]
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
        public virtual ICollection<Poblacion> Poblaciones { get; set; } = [];
    }
}
