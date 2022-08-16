using System.Collections.Generic;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.LoggerSystem;
using UnityEngine;

namespace TimberApi.Internal.LoggerSystem
{
    public class ConsoleLogger : IConsoleWriter
    {
        public delegate void LogCallback(string condition, string stackTrace, LogType type);

        public event LogCallback LogMessageReceived = null!;

        private static ConsoleLogger _instance = null!;

        public static ConsoleLogger Instance => _instance ??= new ConsoleLogger();

        public List<Log> LogHistory;

        public ConsoleLogger()
        {
            LogHistory = new List<Log>();
        }

        public void Log(string message)
        {
            LogHistory.Add(Core.LoggerSystem.Log.Create(message, "", LogType.Assert));
            OnLogMessageReceived(message, "", LogType.Assert);
        }

        protected virtual void OnLogMessageReceived(string condition, string stacktrace, LogType type)
        {
            LogMessageReceived?.Invoke(condition, stacktrace, type);
        }
    }
}