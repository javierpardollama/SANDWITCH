using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Updates
{
    public class UpdateArenal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<int> PoblacionesId { get; set; }
    }
}
