using System;
using System.Collections.Generic;
using System.IO;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.LoggingSystem
{
    public class ConsoleMonitorController
    {
        private bool _isConsoleVisible = true;

        private readonly VisualElement _root;

        private readonly ScrollView _logScrollView;

        private readonly VisualElement _settingsWrapper;

        private bool _isSettingVisible;

        private readonly TextField _logs;

        private readonly List<VisualElement> _pickingModeElements;

        public ConsoleMonitorController(VisualElement root)
        {
            try
            {
                _root = root;
                _settingsWrapper = _root.Q<VisualElement>("settingsWrapper");
                _logs = _root.Q<TextField>("LogTextField");
                _logScrollView = _root.Q<TextField>("LogTextField").Q<ScrollView>();
                _logScrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;

                _pickingModeElements = new List<VisualElement>();
                SetClickThroughElements();
                InitializeEvents();
                SetDefaults();
            }
            catch (Exception e)
            {
                File.WriteAllText("tex.txt", e.ToString());
                throw;
            }
        }

        public void ToggleConsole()
        {
            _isConsoleVisible = !_isConsoleVisible;
            _root.ToggleDisplayStyle(_isConsoleVisible);
        }

        private void SetDefaults()
        {
            _root.Q<Toggle>("ClickThoughToggle").value = true;
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
            _pickingModeElements.Add(_root.Q<VisualElement>("contentWrapper"));
            _pickingModeElements.Add(_root.Q<VisualElement>("settingsWrapper"));
            //
            // // LogTextField
            var textField = _root.Q<TextField>("LogTextField");
            _pickingModeElements.Add(textField);
            var textFieldInput = textField.Q<TextField.TextInput>("unity-text-input");
            _pickingModeElements.Add(textFieldInput);
            var container = textFieldInput.Q<VisualElement>("unity-content-and-vertical-scroll-container");
            _pickingModeElements.Add(container);
            _pickingModeElements.Add(container.parent.contentContainer);
            _pickingModeElements.Add(container.parent);
            _pickingModeElements.Add(container.Q<TextElement>());
        }

        private void InitializeEvents()
        {
            _root.Q<Button>("SettingsButton").clicked += OnSettingsButtonClick;
            _root.Q<Button>("CopyFullLogButton").clicked += OnCopyFullLogButtonClick;
            _root.Q<Toggle>("ClickThoughToggle").RegisterValueChangedCallback(OnSeeTroughValidateValue);
            _logs.RegisterValueChangedCallback(AutoScrollDownCallback);

        }

        private void AutoScrollDownCallback(ChangeEvent<string> evt)
        {
            _logScrollView.verticalScroller.value = _logScrollView.verticalScroller.highValue;
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
            GUIUtility.systemCopyBuffer = _logs.text;
        }

        private void OnSettingsButtonClick()
        {
            _isSettingVisible = !_isSettingVisible;
            _settingsWrapper.ToggleDisplayStyle(_isSettingVisible);
        }

        public void AddLog(string message, string stackTrace, LogType logType)
        {
            _logs.value += logType == LogType.Exception ? $"{message}\n{stackTrace}\n" : $"{message}\n";
        }
    }
}