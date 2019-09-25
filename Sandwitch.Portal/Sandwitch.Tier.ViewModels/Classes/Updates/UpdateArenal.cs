using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    public class UpdateArenal : UpdateBase
    {
        public UpdateArenal()
        {
        }

        public string Name { get; set; }

        public virtual IList<int> PoblacionesId { get; set; }
    }
}
