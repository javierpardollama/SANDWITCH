using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Constants.Enums;

namespace Sandwitch.Tier.Mappings.Classes
{
    public static class LoggingProfile
    {
        public static readonly Dictionary<Enum, LogLevel> LogLevelMapings = new Dictionary<Enum, LogLevel>
    {
    { ApplicationEvents.InsertItem, LogLevel.Information },
    { ApplicationEvents.UpdateItem, LogLevel.Information },
    { ApplicationEvents.DeleteItem, LogLevel.Information },
    { ApplicationEvents.GetItemNotFound, LogLevel.Error },
    { ApplicationEvents.GetItemFound, LogLevel.Error }
    };

    }
}