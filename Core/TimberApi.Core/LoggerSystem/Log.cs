using UnityEngine;

namespace TimberApi.Core.LoggerSystem
{
    public class Log
    {
        public string Message;

        public string StackTrace;

        public LogType LogType;

        public Log(string message, string stackTrace, LogType logType)
        {
            Message = message;
            StackTrace = stackTrace;
            LogType = logType;
        }

        public static Log Create(string message, string stackOverflow, LogType logType)
        {
            return new Log(message, stackOverflow, logType);
        }
    }
}