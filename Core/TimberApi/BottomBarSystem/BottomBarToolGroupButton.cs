using Timberborn.ToolSystem;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolGroupButton
    {
        public BottomBarToolGroupSpecification Specification { get; }

        public BottomBarToolGroup ToolGroup { get; }

        public ToolGroupButton ToolGroupButton { get; }

        public int Row { get; }

        public BottomBarToolGroupButton(BottomBarToolGroupSpecification specification, BottomBarToolGroup toolGroup, ToolGroupButton toolGroupButton, int row)
        {
            Specification = specification;
            ToolGroup = toolGroup;
            ToolGroupButton = toolGroupButton;
            Row = row;
        }
    }
}