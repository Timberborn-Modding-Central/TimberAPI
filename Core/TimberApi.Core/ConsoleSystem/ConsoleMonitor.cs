using System;
using System.IO;
using System.Linq;
using TimberApi.Core.ConsoleSystemUi;
using TimberApi.Core.LoggingSystem;
using TimberApi.Core2.Common;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystem
{
    public class ConsoleMonitor : MonoBehaviour, ILogListener
    {
        private ConsoleMonitorController _monitorController = null!;

        private KeyboardController _keyboardController = null!;

        private bool _isGravePressed;

        private void Awake()
        {
            try
            {
                _keyboardController = GetComponent<KeyboardController>();
                var uiDocument = GetComponent<UIDocument>();
                uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>().First(document => document != uiDocument).panelSettings;
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

        private void OnUnityLogMessageReceived(string message, string stacktrace, LogType type)
        {
            _monitorController.AddLog("Unity", message, stacktrace, type, LogTextColors.Internal[type]);
        }

        private void Update()
        {
            if(!_keyboardController.IsKeyHeld(Key.Backquote))
            {
                _isGravePressed = false;
            }

            if (!_keyboardController.IsKeyHeld(Key.Backquote) || _isGravePressed)
            {
                return;
            }

            _isGravePressed = true;
            _monitorController.ToggleConsole();
        }

        public void OnLogMessageReceived(string tagName, string message, string stacktrace, LogType type, Color color)
        {
            _monitorController.AddLog(tagName, message, stacktrace, type, color);
        }
    }
}