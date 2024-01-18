using Timberborn.ToolSystem;
using Timberborn.WaterBrushesUI;

namespace TimberApi.ToolSystem.Tools.WaterGenerator
{
    public class WaterGeneratorToolFactory : IToolFactory
    {
        public string Id => "WaterGeneratorTool";

        private readonly WaterHeightBrushTool _waterHeightBrushTool;

        public WaterGeneratorToolFactory(WaterHeightBrushTool waterHeightBrushTool)
        {
            _waterHeightBrushTool = waterHeightBrushTool;
        }

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _waterHeightBrushTool.ToolGroup = toolGroup;
            return _waterHeightBrushTool;
        }
    }
}