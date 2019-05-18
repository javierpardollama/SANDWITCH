using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Logging.Enums;
using System;
using System.Collections.Generic;

namespace Sandwitch.Tier.Logging.Mapping
{
    public static class LoggingProfile
    {
        public static readonly Dictionary<Enum, LogLevel> LogLevelMapings = new Dictionary<Enum, LogLevel>
    {    
    { ApplicationEvents.InsertItem, LogLevel.Information },
    { ApplicationEvents.UpdateItem, LogLevel.Information },
    { ApplicationEvents.DeleteItem, LogLevel.Information },
    { ApplicationEvents.GetItemNotFound, LogLevel.Error },
    { ApplicationEvents.InsertItemAlreadyFound, LogLevel.Error }
    };

    }
}