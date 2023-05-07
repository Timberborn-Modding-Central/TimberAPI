using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    public class TreeCuttingAreaSelectionToolFactory : IToolFactory
    {
        public string Id => "TreeCuttingAreaSelectionTool";
        
        private readonly TreeCuttingAreaSelectionTool _treeCuttingAreaSelectionTool;

        public TreeCuttingAreaSelectionToolFactory(TreeCuttingAreaSelectionTool treeCuttingAreaSelectionTool)
        {
            _treeCuttingAreaSelectionTool = treeCuttingAreaSelectionTool;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            return _treeCuttingAreaSelectionTool;
        }
    }
}