using System.Collections.Generic;
using System.Collections.Immutable;
using UnityEngine;

namespace TimberApi.Core.LoggingSystem
{
    internal class Logger
    {
        private readonly ImmutableArray<ILogListener> _listeners;

        public Logger(IEnumerable<ILogListener> listeners)
        {
            _listeners = listeners.ToImmutableArray();
        }

        public void SendLogToListeners(string tagName, string message, string stacktrace, LogType type, Color? color = null)
        {
            Color logColor = color ?? LogTextColors.Default[type];
            foreach (ILogListener logListener in _listeners)
            {
                logListener.OnLogMessageReceived(tagName, message, stacktrace, type, logColor);
            }
        }
    }
}