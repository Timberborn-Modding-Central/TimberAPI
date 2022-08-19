using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.LoggingSystem.Ui
{
    public static class ConsoleLogItemUi
    {
        public static VisualElement Create(string message)
        {
            var item = new VisualElement() { style = { marginTop = -9 }};

            item.Add(new Label()
            {
                text = message,
                style =
                {
                    color = Color.white,
                }
            });

            return item;
        }
    }
}