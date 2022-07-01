
using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Constants.Enums;

namespace Sandwitch.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="LoggingProfile"/> class
    /// </summary>
    public static class LoggingProfile
    {
        /// <summary>
        /// Instance of <see cref="Dictionary{Enum, LogLevel}"/>
        /// </summary>
        public static readonly Dictionary<Enum, LogLevel> LogLevelMapings = new()
        {
    { ApplicationEvents.InsertItem, LogLevel.Information },
    { ApplicationEvents.UpdateItem, LogLevel.Information },
    { ApplicationEvents.DeleteItem, LogLevel.Information },
    { ApplicationEvents.GetItemNotFound, LogLevel.Error },
    { ApplicationEvents.GetItemFound, LogLevel.Error }
    };

    }
}