using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolButton
    {
        public ToolSpecification Specification { get; }

        public ToolButton ToolButton { get; }

        public Tool Tool { get; }

        public BottomBarToolButton(ToolSpecification specification, ToolButton toolButton, Tool tool)
        {
            Specification = specification;
            ToolButton = toolButton;
            Tool = tool;
        }
    }
}