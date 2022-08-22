using System.Collections.Generic;
using UnityEngine;

namespace TimberApi.Core.LoggingSystem
{
    public static class LogTextColors
    {
        public static Dictionary<LogType, Color> Default = new Dictionary<LogType, Color>()
        {
            {LogType.Log, new Color(0.94f, 0.94f, 0.94f)},
            {LogType.Assert, Color.yellow},
            {LogType.Warning, Color.yellow},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red}
        };

        public static Dictionary<LogType, Color> Internal = new Dictionary<LogType, Color>()
        {
            {LogType.Log, new Color(0.88f, 0.88f, 0.88f)},
            {LogType.Assert, Color.yellow},
            {LogType.Warning, Color.yellow},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red}
        };
    }
}