﻿using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateViento"/> class. Inherits <see cref="UpdateBase"/>
    /// </summary>
    public class UpdateViento : UpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateViento"/>
        /// </summary>
        public UpdateViento()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [Required]
        [Url]
        public string ImageUri { get; set; }
    }
}
