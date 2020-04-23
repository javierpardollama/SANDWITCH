using System;

using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Constants.Enums;
using Sandwitch.Tier.Mappings.Classes;

namespace Sandwitch.Tier.Logging.Classes
{
    /// <summary>
    /// Represents a <see cref="LoggingTransistor"/> class
    /// </summary>
    public static class LoggingTransistor
    {
        /// <summary>
        /// Instance of <see cref="LogLevel"/>
        /// </summary>
        private const LogLevel DefaultLogLevel = LogLevel.None;

        /// <summary>
        /// Emits
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="appEventData">Injected <see cref="Enum"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        private static void Emit(this ILogger @this,
                                 Enum appEventData,
                                 string logData) => @this.Log(
                GetApplicationEventLevel(appEventData),
                GetApplicationEventCode(appEventData),
                logData,
                DateTime.Now.ToShortDateString());

        /// <summary>
        /// Emits Not Found
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        public static void WriteGetItemNotFoundLog(this ILogger @this,
                                                   string logData)
        {
            @this.Emit(ApplicationEvents.GetItemNotFound,
                       logData);

            WriteDiagnostics(logData);
        }

        /// <summary>
        /// Emits Update
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        public static void WriteUpdateItemLog(this ILogger @this,
                                              string logData)
        {
            @this.Emit(ApplicationEvents.UpdateItem,
                       logData);

            WriteDiagnostics(logData);
        }

        /// <summary>
        /// Emits Delete
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        public static void WriteDeleteItemLog(this ILogger @this,
                                              string logData)
        {
            @this.Emit(ApplicationEvents.DeleteItem,
                       logData);

            WriteDiagnostics(logData);
        }

        /// <summary>
        /// Emits Insert
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        public static void WriteInsertItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.InsertItem,
                       logData);

            WriteDiagnostics(logData);
        }

        /// <summary>
        /// Emits Found
        /// </summary>
        /// <param name="this">Injected <see cref="ILogger"/></param>
        /// <param name="logData">Injected <see cref="string"/></param>
        public static void WriteGetItemFoundLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.GetItemFound,
                       logData);

            WriteDiagnostics(logData);
        }

        /// <summary>
        /// Writes Diagnostics
        /// </summary>
        /// <param name="logData">Injected <see cref="string"/></param>
        private static void WriteDiagnostics(string logData) => System.Diagnostics.Debug.WriteLine(logData);

        /// <summary>
        /// Gets Application Event Code
        /// </summary>
        /// <param name="appEventData">Injected <see cref="Enum"/></param>
        /// <returns></returns>
        private static int GetApplicationEventCode(Enum appEventData) => (int)Convert.ChangeType(appEventData, appEventData.GetTypeCode());

        /// <summary>
        /// Gets Application Event Level
        /// </summary>
        /// <param name="appEventData">Injected <see cref="Enum"/></param>
        /// <returns></returns>
        private static LogLevel GetApplicationEventLevel(Enum appEventData)
        {
            if (LoggingProfile.LogLevelMapings.ContainsKey(appEventData))
            {
                return LoggingProfile.LogLevelMapings[appEventData];
            }
            else
            {
                return DefaultLogLevel;
            }
        }
    }
}