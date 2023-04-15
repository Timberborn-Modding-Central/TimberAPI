using Timberborn.Core;
using Timberborn.Debugging;
using Timberborn.ToolSystem;
using UnityEngine.UIElements;

namespace TimberApi.ToolSystem
{
    public class TestButton : ToolButton
    {
        public TestButton(ToolManager toolManager, DevModeManager devModeManager, ToolGroupManager toolGroupManager, MapEditorMode mapEditorMode, Tool tool, VisualElement root, Button button) : base(toolManager, devModeManager, toolGroupManager, mapEditorMode, tool, root, button)
        {
        }
    }
}