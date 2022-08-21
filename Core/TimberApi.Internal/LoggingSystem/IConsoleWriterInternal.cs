using UnityEngine;

namespace TimberApi.Internal.LoggingSystem
{
    public interface IConsoleWriterInternal
    {
        void Log(string message, LogType type = LogType.Log, Color? color = null);

        void Log(string tagName, string message, LogType type, Color? color = null);
    }
}