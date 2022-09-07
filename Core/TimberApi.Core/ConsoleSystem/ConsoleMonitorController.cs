using System.Collections.Generic;
using TimberApi.Core.ConsoleSystemUi;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleMonitorController
    {
        private readonly List<string> _logHistory;

        private bool _isConsoleVisible = true;

        private readonly VisualElement _root;

        private readonly ScrollView _logScrollView;

        private readonly VisualElement _settingsWrapper;

        private bool _isSettingVisible;

        private readonly List<VisualElement> _pickingModeElements;

        private string? _latestMessage;
        private TextElement? _latestMessageElement;
        private uint _latestMessageRepeat;

        private string? _secondLatestMessage;
        private TextElement? _secondLatestMessageElement;
        private uint _secondLatestMessageRepeat;

        public ConsoleMonitorController(VisualElement root)
        {
            _logHistory = new List<string>();
            _root = root;
            _settingsWrapper = _root.Q<VisualElement>("SettingsWrapper");
            _logScrollView = _root.Q<ScrollView>("LogScrollView");
            _pickingModeElements = new List<VisualElement>();
            SetClickThroughElements();
            InitializeEvents();
            SetDefaults();
        }

        public void ToggleConsole()
        {
            _isConsoleVisible = !_isConsoleVisible;
            _root.ToggleDisplayStyle(_isConsoleVisible);
        }

        private void SetDefaults()
        {
            _root.Q<Toggle>("ClickThroughToggle").value = true;
            _root.ToggleDisplayStyle(_isConsoleVisible);
        }

        /// <summary>
        /// Making the console click through is a mess
        /// All elements that should not block the click should be listed here
        /// </summary>
        private void SetClickThroughElements()
        {
            _pickingModeElements.Add(_root.Q<VisualElement>("Monitor"));
            _pickingModeElements.Add(_root.Q<VisualElement>("HeaderWrapper"));
            _pickingModeElements.Add(_root.Q<VisualElement>("ContentWrapper"));
            _pickingModeElements.Add(_root.Q<VisualElement>("SettingsWrapper"));

            // Scroll view
            _pickingModeElements.Add(_logScrollView);
            _pickingModeElements.Add(_logScrollView.contentContainer);
            _pickingModeElements.Add(_logScrollView.Q("unity-content-and-vertical-scroll-container"));
        }

        private void InitializeEvents()
        {
            _root.Q<Button>("SettingsButton").clicked += OnSettingsButtonClick;
            _root.Q<Button>("CopyFullLogButton").clicked += OnCopyFullLogButtonClick;
            _root.Q<Toggle>("ClickThroughToggle").RegisterValueChangedCallback(OnSeeTroughValidateValue);
        }

        private void OnSeeTroughValidateValue(ChangeEvent<bool> isPickModeSeeThrough)
        {
            PickingMode mode = isPickModeSeeThrough.newValue ? PickingMode.Ignore : PickingMode.Position;

            foreach (VisualElement element in _pickingModeElements)
            {
                element.pickingMode = mode;
            }
        }

        private void OnCopyFullLogButtonClick()
        {
            GUIUtility.systemCopyBuffer = string.Join("\n", _logHistory);
        }

        private void OnSettingsButtonClick()
        {
            _isSettingVisible = !_isSettingVisible;
            _settingsWrapper.ToggleDisplayStyle(_isSettingVisible);
        }

        public void AddLog(string tagName, string message, string stackTrace, LogType logType, Color color)
        {
            string text = logType == LogType.Exception ? $"{message}\n{stackTrace}" : $"[{logType} : {tagName}] {message}";
            if (TryMergeRepeatedMessage(text))
            {
                return;
            }

            TextElement newItem = ConsoleLogItemUi.Create(text, color);

            _secondLatestMessage = _latestMessage;
            _secondLatestMessageElement = _latestMessageElement;
            _secondLatestMessageRepeat = 0;

            _latestMessage = text;
            _latestMessageElement = newItem;
            _latestMessageRepeat = 0;

            _logHistory.Add(text);
            _logScrollView.Add(newItem);
            _logScrollView.verticalScroller.value = _logScrollView.verticalScroller.highValue > 0 ? _logScrollView.verticalScroller.highValue : 0;
        }

        public bool TryMergeRepeatedMessage(string message)
        {
            if (_latestMessage != null && _latestMessage.Equals(message))
            {
                _latestMessageElement!.text = $"[Repeat: {_latestMessageRepeat}] " + message;
                _latestMessageRepeat++;
                return true;
            }

            if (_secondLatestMessage != null && _secondLatestMessage.Equals(message))
            {
                _secondLatestMessageElement!.text = $"[Repeat: {_secondLatestMessageRepeat}] " + message;
                _secondLatestMessageRepeat++;
                return true;
            }

            return false;
        }
    }
}