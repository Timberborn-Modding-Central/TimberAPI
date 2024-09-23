using Timberborn.ToolSystem;
using Timberborn.WaterBrushesUI;

namespace TimberApi.Tools.ToolSystem.Tools.WaterGenerator;

public class WaterGeneratorToolFactory(WaterHeightBrushTool waterHeightBrushTool) : IToolFactory
{
    public string Id => "WaterGeneratorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        waterHeightBrushTool.ToolGroup = toolGroup;
        return waterHeightBrushTool;
    }
}