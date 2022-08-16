using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.ConsoleSystem.Ui
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
                    fontSize = 23,
                    color = Color.white,
                }
            });

            return item;
        }
    }
}