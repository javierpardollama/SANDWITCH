using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Additions
{
    public class AddArenal
    {
        public string Name { get; set; }

        public virtual ICollection<int> PoblacionesId { get; set; }
    }
}
