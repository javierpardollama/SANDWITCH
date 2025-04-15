using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Constants.Enums;
using System;

namespace Sandwitch.Tier.Mappings.Classes
{
    /// <summary>
    /// Represents a <see cref="LoggingProfile"/> class
    /// </summary>
    public static class LoggingProfile
    {
        /// <summary>
        /// Maps
        /// </summary>
        /// <param name="enum">Injected <see cref="Enum"/></param>
        /// <returns>Instance of <see cref="LogLevel"/></returns>
        public static LogLevel Map(Enum @enum)
        {
            return @enum switch
            {
                 ApplicationEvents.InsertItem => LogLevel.Information,
                 ApplicationEvents.UpdateItem => LogLevel.Information,
                 ApplicationEvents.DeleteItem => LogLevel.Information,
                 ApplicationEvents.GetItemNotFound => LogLevel.Error,
                 ApplicationEvents.GetItemFound => LogLevel.Error,
                 _ => LogLevel.None,
            };
        }        
    }
}