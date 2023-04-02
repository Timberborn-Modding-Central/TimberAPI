using TimberApi.ToolGroupSystem;
using Timberborn.ToolSystem;
using ToolGroupSpecification = TimberApi.ToolGroupSystem.ToolGroupSpecification;

namespace TimberApi.BottomBarSystem
{
    public class BottomBarToolGroupButton
    {
        public ToolGroupSpecification Specification { get; }

        public ApiToolGroup ToolGroup { get; }

        public ToolGroupButton ToolGroupButton { get; }

        public int Row { get; }

        public BottomBarToolGroupButton(ToolGroupSpecification specification, ApiToolGroup toolGroup, ToolGroupButton toolGroupButton, int row)
        {
            Specification = specification;
            ToolGroup = toolGroup;
            ToolGroupButton = toolGroupButton;
            Row = row;
        }
    }
}