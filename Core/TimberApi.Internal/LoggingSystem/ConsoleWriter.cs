using TimberApi.Core.LoggerSystem;
using TimberApi.Core.ModSystem;
using UnityEngine;

namespace TimberApi.Internal.LoggingSystem
{
    internal class ConsoleWriter : IConsoleWriter
    {
        private readonly Logger _logger;

        private readonly IModRepository _modRepository;

        public ConsoleWriter(Logger logger, IModRepository modRepository)
        {
            _logger = logger;
            _modRepository = modRepository;
        }

        public void Log(string message, LogType type, Color color)
        {
            throw new System.NotImplementedException();
        }

        public void Log(string message, LogType type)
        {
            throw new System.NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogAssert(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new System.NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}