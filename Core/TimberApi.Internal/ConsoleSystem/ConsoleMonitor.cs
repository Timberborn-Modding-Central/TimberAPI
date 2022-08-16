using System.Linq;
using TimberApi.Internal.ConsoleSystem.Ui;
using TimberApi.Internal.LoggerSystem;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace TimberApi.Internal.ConsoleSystem
{
    public class ConsoleMonitor : MonoBehaviour
    {
        private ConsoleMonitorController _monitorController = null!;

        private KeyboardController _keyboardController = null!;

        private bool _isGravePressed;

        private void Awake()
        {
            _keyboardController = gameObject.AddComponent<KeyboardController>();

            var uiDocument = GetComponent<UIDocument>();
            uiDocument.panelSettings = Resources.FindObjectsOfTypeAll<UIDocument>().First(document => document != uiDocument).panelSettings;
            uiDocument.sortingOrder = 10000;

            VisualElement consoleMonitor = ConsoleMonitorUi.Create();
            uiDocument.rootVisualElement.Add(consoleMonitor);

            _monitorController = new ConsoleMonitorController(consoleMonitor);
            _monitorController.ClearAndLoadHistory();
        }



        void OnEnable()
        {
            ConsoleLogger.Instance.LogMessageReceived += _monitorController.AddLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= _monitorController.AddLog;
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
    }
}