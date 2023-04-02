using TimberApi.ToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolButton
    {
        public ToolSpecification Specification { get; }

        public ToolButton ToolButton { get; }

        public Tool Tool { get; }

        public BottomBarToolButton(ToolSpecification specification, Tool tool, ToolButton toolButton)
        {
            Specification = specification;
            ToolButton = toolButton;
            Tool = tool;
        }
    }
}