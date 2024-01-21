
using Timberborn.ForestryUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.TreeCuttingArea
{
    public class TreeCuttingAreaUnselectionToolFactory : IToolFactory
    {
        public string Id => "TreeCuttingAreaUnselectionTool";

        private readonly TreeCuttingAreaUnselectionTool _treeCuttingAreaUnselectionTool;
        
        public TreeCuttingAreaUnselectionToolFactory(TreeCuttingAreaUnselectionTool treeCuttingAreaUnselectionTool)
        {
            _treeCuttingAreaUnselectionTool = treeCuttingAreaUnselectionTool;
        }
        
        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _treeCuttingAreaUnselectionTool.ToolGroup = toolGroup;
            
            return _treeCuttingAreaUnselectionTool;
        }
    }
}