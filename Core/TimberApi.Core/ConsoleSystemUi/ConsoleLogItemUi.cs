using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystemUi
{
    internal static class ConsoleLogItemUi
    {
        public static VisualElement Create()
        {
            return new TextElement
            {
                pickingMode = PickingMode.Ignore,
                style =
                {
                    textOverflow = TextOverflow.Ellipsis,
                    fontSize = 21
                }
            };
        }
    }
}