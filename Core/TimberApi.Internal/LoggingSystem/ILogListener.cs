using UnityEngine;

namespace TimberApi.Internal.LoggingSystem
{
    public interface ILogListener
    {
        void OnLogMessageReceived(string message, string stacktrace, LogType type);
    }
}