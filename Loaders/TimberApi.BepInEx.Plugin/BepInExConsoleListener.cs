using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;
using ILogListener = TimberApi.Core.LoggingSystem.ILogListener;

namespace TimberApi.BepInExPlugin
{
    public class BepInExConsoleListener : ILogListener
    {
        private readonly Dictionary<LogType, LogLevel> _logLevelDirectory = new Dictionary<LogType, LogLevel>()
        {
            { LogType.Assert, LogLevel.Debug },
            { LogType.Error, LogLevel.Error },
            { LogType.Exception, LogLevel.Fatal },
            { LogType.Log, LogLevel.Info },
            { LogType.Warning, LogLevel.Warning },
        };


        public void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color)
        {
            BepInEx.Logging.Logger.CreateLogSource(tagName).Log(_logLevelDirectory[type], message);
        }
    }
}