using UnityEngine;

namespace TimberApi.Core2.ConsoleSystem
{
    public interface IConsoleWriter
    {
        void Log(string message, LogType type, Color color);

        void Log(string message, LogType type);

        void LogInfo(string message);

        void LogAssert(string message);

        void LogWarning(string message);

        void LogError(string message);
    }
}