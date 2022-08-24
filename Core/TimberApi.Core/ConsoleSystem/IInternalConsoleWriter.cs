using UnityEngine;

namespace TimberApi.Core.ConsoleSystem
{
    public interface IInternalConsoleWriter
    {
        void Log(string message, LogType type = LogType.Log, Color? color = null);

        void Log(string tagName, string message, LogType type, Color? color = null);

        void LogAs(string tagName, string message, LogType type, Color? color = null);
    }
}