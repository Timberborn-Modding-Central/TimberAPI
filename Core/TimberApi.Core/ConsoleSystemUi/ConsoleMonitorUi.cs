using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystemUi
{
    internal static class ConsoleMonitorUi
    {
        public static VisualElement Create()
        {
            var monitor = new VisualElement
            {
                name = "Monitor",
                style =
                {
                    position = Position.Absolute,
                    left = 0,
                    top = 0,
                    right = 0,
                    bottom = 0,
                }
            };

            var headerWrapper = new VisualElement()
            {
                name = "HeaderWrapper",
                style =
                {
                    backgroundColor = new Color(0.06f, 0.06f, 0.06f, 0.7f),
                    flexDirection = FlexDirection.Column,
                    justifyContent = Justify.Center,
                    height = 40,
                }
            };
            headerWrapper.Add(ConsoleHeaderUi.Create());

            var contentWrapper = new VisualElement()
            {
                name = "ContentWrapper",
                style =
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f, 0.7f),
                    flexGrow = 1
                }
            };
            contentWrapper.Add(new ScrollView() { name = "LogScrollView", verticalScrollerVisibility = ScrollerVisibility.AlwaysVisible});

            var settingsWrapper = new VisualElement()
            {
                name = "SettingsWrapper",
                style =
                {
                    display = DisplayStyle.None,
                    backgroundColor = new Color(0.14f, 0.14f, 0.14f, 0.7f),
                    position = Position.Absolute,
                    top = 0,
                    right = 0,
                    bottom = 0,
                    width = 400
                }
            };
            settingsWrapper.Add(ConsoleSettingUi.Create());

            monitor.Add(headerWrapper);
            monitor.Add(contentWrapper);
            contentWrapper.Add(settingsWrapper);

            return monitor;
        }
    }
}