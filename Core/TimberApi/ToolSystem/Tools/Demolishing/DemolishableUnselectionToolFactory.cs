using Timberborn.DemolishingUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Demolishing
{
    public class DemolishableUnselectionToolFactory : IToolFactory
    {
        private readonly DemolishableUnselectionTool _demolishableUnselectionTool;

        public DemolishableUnselectionToolFactory(DemolishableUnselectionTool demolishableUnselectionTool)
        {
            _demolishableUnselectionTool = demolishableUnselectionTool;
        }

        public string Id => "DemolishableUnselectionTool";

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _demolishableUnselectionTool.Initialize(toolGroup);
            return _demolishableUnselectionTool;
        }
    }
}