﻿using System.Collections.Generic;
using UnityEngine;

namespace TimberApi.Core.LoggingSystem
{
    public static class LogTextColors
    {
        public static Dictionary<LogType, Color> Default = new()
        {
            {LogType.Log, new Color(0.94f, 0.94f, 0.94f)},
            {LogType.Assert, Color.yellow},
            {LogType.Warning, Color.yellow},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red}
        };

        public static Dictionary<LogType, Color> Internal = new()
        {
            {LogType.Log, new Color(0.65f, 0.65f, 0.65f)},
            {LogType.Assert, Color.yellow},
            {LogType.Warning, Color.yellow},
            {LogType.Error, Color.red},
            {LogType.Exception, Color.red}
        };
    }
}