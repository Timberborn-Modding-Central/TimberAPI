using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.Internal.LoggingSystem
{
    internal class Logger
    {
        private readonly ImmutableArray<ILogListener> _listeners;

        public static Dictionary<LogType, Color> LogColors = new Dictionary<LogType, Color>()
        {
            {LogType.Log, Color.white},
            {LogType.Assert, Color.yellow},
            {LogType.Warning, Color.yellow},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red}
        };

        public Logger(IEnumerable<ILogListener> listeners)
        {
            _listeners = listeners.ToImmutableArray();
        }

        public void SendLogToListeners(string tagName, string message, string stacktrace, LogType type, Color? color = null)
        {
            Color logColor = color ?? LogColors[type];
            foreach (ILogListener logListener in _listeners)
            {
                logListener.OnLogMessageReceived(tagName, message, stacktrace, type, logColor);
            }
        }
    }
}