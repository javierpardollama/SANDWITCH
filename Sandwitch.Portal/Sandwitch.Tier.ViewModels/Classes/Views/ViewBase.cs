using System;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    public abstract class ViewBase
    {
        public int Id { get; set; }

        public DateTime LastModified { get; set; }
    }
}
