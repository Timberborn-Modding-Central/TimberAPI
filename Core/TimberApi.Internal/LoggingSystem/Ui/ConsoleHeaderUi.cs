using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.LoggingSystem.Ui
{
    public static class ConsoleHeaderUi
    {
        public static VisualElement Create()
        {
            var header = new VisualElement() { style = { flexDirection = FlexDirection.Row, justifyContent = Justify.SpaceBetween}};

            var settingsBox = new VisualElement() { style = { alignItems = Align.Center}} ;
            settingsBox.Add(new Button() { name = "SettingsButton", text = "Settings", style = { width = 100, fontSize = 16, marginBottom = 3, marginTop = 3, color = Color.white, display = DisplayStyle.None }});
            settingsBox.Add(new Toggle("Console click through") { name = "ClickThroughToggle", style = { fontSize = 20, color = Color.white }});

            var actionBox = new VisualElement() {style = { flexDirection = FlexDirection.Row, alignItems = Align.Center }};
            var tagSearchWrapper = new VisualElement() { style = { display = DisplayStyle.None }};
            tagSearchWrapper.Add(new Label("Search mod tag") { style = { fontSize = 25, color = Color.white }});
            tagSearchWrapper.Add(new TextField() { name = "TagNameSearch", style = { width = 250}});
            actionBox.Add(tagSearchWrapper);

            actionBox.Add(new Button() {name = "CopyFullLogButton", text = "Copy log", style = {width = 200, height = 40, fontSize = 25, color = Color.white}});

            header.Add(actionBox);
            header.Add(settingsBox);
            return header;
        }
    }
}