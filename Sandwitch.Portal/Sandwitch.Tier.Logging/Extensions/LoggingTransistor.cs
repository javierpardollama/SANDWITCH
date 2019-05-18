using Microsoft.Extensions.Logging;
using Sandwitch.Tier.Logging.Enums;
using Sandwitch.Tier.Logging.Mapping;
using System;

namespace Sandwitch.Tier.Logging.Extensions
{
    public  static class LoggingTransistor
    {
        private const LogLevel DefaultLogLevel = LogLevel.None;

        private static void Emit(this ILogger @this, Enum applicationEvent, string logData)
        {
            int applicationEventCode = GetApplicationEventCode(applicationEvent);
            LogLevel applicationEventLevel = GetApplicationEventLevel(applicationEvent);
            @this.Log(applicationEventLevel, applicationEventCode, logData);
        }

        public static void WriteGetItemNotFoundLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.GetItemNotFound, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteUpdateItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.UpdateItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteDeleteItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.DeleteItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteInsertItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.InsertItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteInsertItemAlreadyFoundLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.InsertItemAlreadyFound, logData);

            WriteDiagnostics(logData);
        }

        private static void WriteDiagnostics(string logData)
        {
            System.Diagnostics.Debug.WriteLine(logData);
        }

        private static int GetApplicationEventCode(Enum applicationEvent)
        {
            return (int)Convert.ChangeType(applicationEvent, applicationEvent.GetTypeCode());
        }

        private static LogLevel GetApplicationEventLevel(Enum applicationEvent)
        {
            if (LoggingProfile.LogLevelMapings.ContainsKey(applicationEvent))
            {
                return LoggingProfile.LogLevelMapings[applicationEvent];
            }
            else
            {
                return DefaultLogLevel;
            }
        }
    }
}