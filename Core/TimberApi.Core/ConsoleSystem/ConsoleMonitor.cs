using System;
using System.IO;
using System.Linq;
using TimberApi.Common;
using TimberApi.Common.LoggingSystem;
using TimberApi.Core.ConsoleSystemUi;
using TimberApi.Core.LoggingSystem;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleMonitor : MonoBehaviour, ILogListener
    {
        private static readonly Key ConsoleKey = Key.Backslash;
        private bool _isConsoleKeyPressed;

        private KeyboardController _keyboardController = null!;
        private ConsoleMonitorController _monitorController = null!;

        private void Awake()
        {
            try
            {
                _keyboardController = GetComponent<KeyboardController>();
                var uiDocument = GetComponent<UIDocument>();
                uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>()
                    .First(document => document != uiDocument).panelSettings;
                uiDocument.sortingOrder = 100000;

                VisualElement consoleMonitor = ConsoleMonitorUi.Create();
                uiDocument.rootVisualElement.Add(consoleMonitor);

                _monitorController = new ConsoleMonitorController(consoleMonitor);
                Application.logMessageReceivedThreaded += OnUnityLogMessageReceived;
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(Paths.Logs, "ConsoleMonitorException.txt"), e.ToString());
                throw;
            }
        }

        private void Update()
        {
            if (!_keyboardController.IsKeyHeld(ConsoleKey))
            {
                _isConsoleKeyPressed = false;
            }

            if (!_keyboardController.IsKeyHeld(ConsoleKey) || _isConsoleKeyPressed)
            {
                return;
            }

            _isConsoleKeyPressed = true;
            _monitorController.ToggleConsole();
        }

        public void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color)
        {
            _monitorController.AddLog(tagName, message, stacktrace, type, color);
        }

        private void OnUnityLogMessageReceived(string message, string stacktrace, LogType type)
        {
            _monitorController.AddLog("Unity", message, stacktrace, type, LogTextColors.Internal[type]);
        }
    }
}
