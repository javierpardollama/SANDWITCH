using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    public class UpdateArenal : UpdateBase
    {
        public string Name { get; set; }

        public virtual ICollection<int> PoblacionesId { get; set; }
    }
}
