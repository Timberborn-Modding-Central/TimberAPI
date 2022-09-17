using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;
using ILogListener = TimberApi.Common.LoggingSystem.ILogListener;
using Logger = BepInEx.Logging.Logger;

namespace TimberApi.BepInExPlugin.Loader
{
    public class BepInExConsoleListener : ILogListener
    {
        private readonly Dictionary<LogType, LogLevel> _logLevel = new()
        {
            {LogType.Assert, LogLevel.Debug},
            {LogType.Error, LogLevel.Error},
            {LogType.Exception, LogLevel.Fatal},
            {LogType.Log, LogLevel.Info},
            {LogType.Warning, LogLevel.Warning}
        };

        private readonly Dictionary<string, ManualLogSource> _logSourceCache = new();

        public void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color)
        {
            if (!_logSourceCache.ContainsKey(tagName))
            {
                _logSourceCache.Add(tagName, Logger.CreateLogSource(tagName));
            }

            _logSourceCache[tagName].Log(_logLevel[type], message);
        }
    }
}