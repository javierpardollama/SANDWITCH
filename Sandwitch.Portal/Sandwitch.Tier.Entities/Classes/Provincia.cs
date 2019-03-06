﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Tier.Entities.Classes
{
    public class Provincia : Base
    {
        public Provincia() { }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Poblacion> Poblaciones { get; set; }
    }
}
