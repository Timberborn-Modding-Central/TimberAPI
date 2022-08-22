using UnityEngine;

namespace TimberApi.Core.LoggingSystem
{
    public interface ILogListener
    {
        void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color);
    }
}