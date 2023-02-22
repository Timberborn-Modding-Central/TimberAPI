using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem
{
    public static class ToolGroupButtonExtensions
    {
        public static void AddToolGroupButton(this ToolGroupButton toolGroupButton, ToolGroupButton childButton)
        {
            toolGroupButton.ToolButtonsElement.Add(childButton.Root);
        }
    }
}