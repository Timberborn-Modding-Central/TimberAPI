using TimberApi.New.ConsoleSystem;
using TimberApi.New.ModSystem;
using UnityEngine;
using Logger = TimberApi.Core.LoggingSystem.Logger;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ManualModConsoleWriter : IConsoleWriter
    {
        private readonly IMod _mod;

        private readonly Logger _logger;

        public ManualModConsoleWriter(Logger logger, IMod mod)
        {
            _logger = logger;
            _mod = mod;
        }

        public void Log(string message, LogType type, Color color)
        {
            _logger.SendLogToListeners(_mod.Name, message, "", type, color);
        }

        public void Log(string message, LogType type)
        {
            _logger.SendLogToListeners(_mod.Name, message, "", type);
        }

        public void LogInfo(string message)
        {
            Log(message, LogType.Log);
        }

        public void LogAssert(string message)
        {
            Log(message, LogType.Assert);
        }

        public void LogWarning(string message)
        {
            Log(message, LogType.Warning);
        }

        public void LogError(string message)
        {
            Log(message, LogType.Error);
        }
    }
}