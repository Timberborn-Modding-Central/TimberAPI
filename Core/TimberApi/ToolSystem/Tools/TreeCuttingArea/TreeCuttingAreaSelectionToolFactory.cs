using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    public class TreeCuttingAreaSelectionToolFactory : IToolFactory
    {
        private readonly TreeCuttingAreaSelectionTool _treeCuttingAreaSelectionTool;

        public TreeCuttingAreaSelectionToolFactory(TreeCuttingAreaSelectionTool treeCuttingAreaSelectionTool)
        {
            _treeCuttingAreaSelectionTool = treeCuttingAreaSelectionTool;
        }

        public string Id => "TreeCuttingAreaSelectionTool";

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return _treeCuttingAreaSelectionTool;
        }
    }
}