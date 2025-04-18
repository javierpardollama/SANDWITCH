﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Bandera"/> class. Inherits <see cref="Base"/>
    /// </summary>
    [Index(nameof(Name), [nameof(Deleted)])]
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
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [Required]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Historicos"/>
        /// </summary>
        public virtual ICollection<Historico> Historicos { get; set; } = [];
    }
}
