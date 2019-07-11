using System;

namespace Sandwitch.Tier.Entities.Interfaces
{
    public interface IBase
    {
        int Id { get; set; }

        DateTime LastModified { get; set; }

        bool Deleted { get; set; }
    }
}
