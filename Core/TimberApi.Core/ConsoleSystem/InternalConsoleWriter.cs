using TimberApi.Core.LoggingSystem;
using UnityEngine;
using Logger = TimberApi.Core.LoggingSystem.Logger;

namespace TimberApi.Core.ConsoleSystem
{
    internal class InternalConsoleWriter : IInternalConsoleWriter
    {
        private readonly Logger _logger;

        public InternalConsoleWriter(Logger logger)
        {
            _logger = logger;
        }

        public void Log(string message, LogType type = LogType.Log, Color? color = null)
        {
            Log("TimberAPI", message, type, color);
        }

        public void Log(string tagName, string message, LogType type, Color? color = null)
        {
            Color logColor = color ?? LogTextColors.Internal[type];
            _logger.SendLogToListeners(tagName, message, "", type, logColor);
        }

        public void LogAs(string tagName, string message, LogType type, Color? color = null)
        {
            _logger.SendLogToListeners(tagName, message, "", type, color);
        }
    }
}