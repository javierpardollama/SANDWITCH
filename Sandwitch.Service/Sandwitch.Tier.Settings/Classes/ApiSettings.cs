using System.Collections.Generic;

namespace Sandwitch.Tier.Settings.Classes
{
    /// <summary>
    /// Represents a <see cref="ApiSettings"/> class
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Gets or Sets <see cref="ApiLock"/>
        /// </summary>
        public string ApiLock { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApiKey"/>
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or Sets <see cref=Clients""/>
        /// </summary>
        public IList<string> Clients { get; set; }
    }
}
