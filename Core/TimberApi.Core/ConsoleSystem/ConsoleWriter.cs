﻿using System.Reflection;
using TimberApi.Core2.ConsoleSystem;
using TimberApi.Core2.ModSystem;
using UnityEngine;

namespace TimberApi.Core.ConsoleSystem
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IModRepository _modRepository;

        private readonly IInternalConsoleWriter _consoleWriter;

        public ConsoleWriter(IModRepository modRepository, IInternalConsoleWriter consoleWriter)
        {
            _modRepository = modRepository;
            _consoleWriter = consoleWriter;
        }

        private void Log(Assembly modAssembly, string message, LogType type, Color? color = null)
        {
            if (!_modRepository.TryGetByAssembly(modAssembly, out IMod mod))
            {
                return;
            }
            _consoleWriter.LogAs(mod.Name, message, type, color);
        }

        public void Log(string message, LogType type, Color color)
        {
            Log(Assembly.GetCallingAssembly(), message, type, color);
        }

        public void Log(string message, LogType type)
        {
            Log(Assembly.GetCallingAssembly(), message, type);
        }

        public void LogInfo(string message)
        {
            Log(Assembly.GetCallingAssembly(), message, LogType.Log);
        }

        public void LogAssert(string message)
        {
            Log(Assembly.GetCallingAssembly(), message, LogType.Assert);
        }

        public void LogWarning(string message)
        {
            Log(Assembly.GetCallingAssembly(), message, LogType.Warning);
        }

        public void LogError(string message)
        {
            Log(Assembly.GetCallingAssembly(), message, LogType.Error);
        }
    }
}