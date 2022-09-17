using UnityEngine;

namespace TimberApi.Common.LoggingSystem
{
    public interface ILogListener
    {
        void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color);
    }
}