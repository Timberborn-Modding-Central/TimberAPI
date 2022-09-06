using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystemUi
{
    internal static class ConsoleLogItemUi
    {
        public static TextElement Create(string text, Color color)
        {
            return new TextElement()
            {
                pickingMode = PickingMode.Ignore,
                text = text,
                style =
                {
                    textOverflow = TextOverflow.Ellipsis,
                    fontSize = 23,
                    color = color
                }
            };
        }
    }
}