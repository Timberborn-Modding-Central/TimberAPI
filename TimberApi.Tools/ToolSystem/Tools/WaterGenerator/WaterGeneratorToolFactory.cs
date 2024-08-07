using Timberborn.ToolSystem;
using Timberborn.WaterBrushesUI;

namespace TimberApi.Tools.ToolSystem.Tools.WaterGenerator;

public class WaterGeneratorToolFactory : IToolFactory
{
    private readonly WaterHeightBrushTool _waterHeightBrushTool;

    public WaterGeneratorToolFactory(WaterHeightBrushTool waterHeightBrushTool)
    {
        _waterHeightBrushTool = waterHeightBrushTool;
    }

    public string Id => "WaterGeneratorTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _waterHeightBrushTool.ToolGroup = toolGroup;
        return _waterHeightBrushTool;
    }
}