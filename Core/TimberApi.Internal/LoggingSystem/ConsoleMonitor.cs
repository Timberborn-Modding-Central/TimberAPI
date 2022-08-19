using System.Linq;
using TimberApi.Internal.LoggingSystem.Ui;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace TimberApi.Internal.LoggingSystem
{
    public class ConsoleMonitor : MonoBehaviour, ILogListener
    {
        private ConsoleMonitorController _monitorController = null!;

        private KeyboardController _keyboardController = null!;

        private bool _isGravePressed;

        private void Awake()
        {
            _keyboardController = GetComponent<KeyboardController>();
            var uiDocument = GetComponent<UIDocument>();
            uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>().First(document => document != uiDocument).panelSettings;
            uiDocument.sortingOrder = float.MaxValue;


            VisualElement consoleMonitor = ConsoleMonitorUi.Create();
            uiDocument.rootVisualElement.Add(consoleMonitor);

            _monitorController = new ConsoleMonitorController(consoleMonitor);
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

        public void OnLogMessageReceived(string message, string stacktrace, LogType type)
        {
            _monitorController.AddLog(message, stacktrace, type);
        }
    }
}