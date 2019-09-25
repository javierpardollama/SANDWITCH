using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Additions
{
    public class AddArenal
    {
        public AddArenal()
        {
        }

        public string Name { get; set; }

        public virtual IList<int> PoblacionesId { get; set; }
    }
}
