using UnityEngine;

namespace TimberApi.Internal.LoggingSystem
{
    internal class ConsoleWriterInternal : IConsoleWriterInternal
    {
        private readonly Logger _logger;

        public ConsoleWriterInternal(Logger logger)
        {
            _logger = logger;
        }

        public void Log(string message, LogType type = LogType.Log, Color? color = null)
        {
            Log("TimberAPI", message, type, color);
        }

        public void Log(string tagName, string message, LogType type, Color? color = null)
        {
            _logger.SendLogToListeners(tagName, message, "", type, color);
        }
    }
}