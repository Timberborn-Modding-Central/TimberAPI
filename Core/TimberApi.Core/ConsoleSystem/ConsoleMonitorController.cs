using System.Collections.Generic;
using System.Linq;
using Timberborn.CoreUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleMonitorController
    {
        private readonly List<LogItem> _logHistory;

        private readonly ListView _logLogListView;

        private readonly List<VisualElement> _pickingModeElements;

        private readonly VisualElement _root;

        private readonly VisualElement _settingsWrapper;

        private bool _isConsoleVisible;

        private bool _isSettingVisible;

        private string? _latestMessage;
        private uint _latestMessageRepeatAmount;

        private string? _secondLatestMessage;
        private uint _secondLatestMessageRepeatAmount;

        public ConsoleMonitorController(VisualElement root)
        {
            _root = root;
            _logHistory = new List<LogItem>();
            _pickingModeElements = new List<VisualElement>();

            _settingsWrapper = _root.Q<VisualElement>("SettingsWrapper");
            _logLogListView = _root.Q<ListView>("LogListView");

            SetupListView();
            SetClickThroughElements();
            InitializeEvents();
            SetDefaults();
        }

        /// <summary>
        ///     Listview requirements
        ///     Adding item and clearing them after adding the source is to remove the list is empty without needing to rebuild the
        ///     whole list every message
        /// </summary>
        private void SetupListView()
        {
            _logHistory.Add(new LogItem("Fake", Color.black));
            _logLogListView.itemsSource = _logHistory;
            _logLogListView.bindItem = BindItem;
            _logLogListView.onSelectionChange += LogLogListViewOnonSelectionChanged;
            _logHistory.Clear();
        }

        private void LogLogListViewOnonSelectionChanged(IEnumerable<object> obj)
        {
            TextElement[] textElements = _logLogListView.Query<TextElement>().Build().ToArray();
            for (var i = 0; i < textElements.Length; i++)
            {
                textElements[i].style.backgroundColor = _logLogListView.selectedIndices.Contains(i) ? new Color(0f, 0f, 0f, 0.39f) : Color.clear;
            }
        }

        private void BindItem(VisualElement label, int logItemIndex)
        {
            LogItem logItem = _logHistory[logItemIndex];
            (label as TextElement)!.text = logItem.Text;
            (label as TextElement)!.style.color = logItem.Color;
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
        ///     Provide all elements that should be click through, used to show the console while still able to click in game
        /// </summary>
        private void SetClickThroughElements()
        {
            _pickingModeElements.Add(_root.Q<VisualElement>("Monitor"));
            _pickingModeElements.Add(_root.Q<VisualElement>("HeaderWrapper"));
            _pickingModeElements.Add(_root.Q<VisualElement>("ContentWrapper"));
            _pickingModeElements.Add(_root.Q<VisualElement>("SettingsWrapper"));

            // Scroll view
            _pickingModeElements.Add(_logLogListView);
            _pickingModeElements.Add(_logLogListView.Q<ScrollView>());
            _pickingModeElements.Add(_logLogListView.Q<ScrollView>().contentContainer);
            _pickingModeElements.Add(_logLogListView.Q("unity-content-and-vertical-scroll-container"));
        }

        private void InitializeEvents()
        {
            _root.Q<Button>("SettingsButton").clicked += OnSettingsButtonClick;
            _root.Q<Button>("CopyFullLogButton").clicked += OnCopyFullLogButtonClick;
            _root.Q<Button>("CopySelectionButton").clicked += OnCopySelectionButtonClick;
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

        private void OnCopySelectionButtonClick()
        {
            GUIUtility.systemCopyBuffer = string.Join("\n", _logLogListView.selectedItems.Select(item => ((LogItem) item).Text));
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

            var logItem = new LogItem(text, color);

            _secondLatestMessage = _latestMessage;
            _secondLatestMessageRepeatAmount = 1;

            _latestMessage = text;
            _latestMessageRepeatAmount = 1;

            _logHistory.Add(logItem);
        }

        public bool TryMergeRepeatedMessage(string message)
        {
            if (_latestMessage != null && _latestMessage.Equals(message))
            {
                _logHistory.Last().Text = $"[Repeat: {_latestMessageRepeatAmount}] " + message;
                _latestMessageRepeatAmount++;
                return true;
            }

            if (_secondLatestMessage != null && _secondLatestMessage.Equals(message))
            {
                _logHistory[^1].Text = $"[Repeat: {_secondLatestMessageRepeatAmount}] " + message;
                _secondLatestMessageRepeatAmount++;
                return true;
            }

            return false;
        }

        private class LogItem
        {
            public LogItem(string text, Color color)
            {
                Text = text;
                Color = color;
            }

            public string Text { get; set; }

            public Color Color { get; }
        }
    }
}