using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Demolishing
{
    public class DemolishableUnselectionToolFactory : IToolFactory
    {
        public string Id => "DemolishableUnselectionTool";

        private readonly DemolishableUnselectionTool _demolishableUnselectionTool;

        public DemolishableUnselectionToolFactory(DemolishableUnselectionTool demolishableUnselectionTool)
        {
            _demolishableUnselectionTool = demolishableUnselectionTool;
        }
        
        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _demolishableUnselectionTool.Initialize(toolGroup);
            return _demolishableUnselectionTool;
        }
    }
}