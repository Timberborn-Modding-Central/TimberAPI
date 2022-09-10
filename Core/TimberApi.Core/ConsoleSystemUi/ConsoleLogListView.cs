using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystemUi
{
    internal static class ConsoleLogListView
    {
        public static ListView Create()
        {
            return new ListView()
            {
                name = "LogListView",
                pickingMode = PickingMode.Ignore,
                makeItem = ConsoleLogItemUi.Create,
                virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight,
                focusable = false,
                selectionType = SelectionType.Multiple,
            };
        }
    }
}