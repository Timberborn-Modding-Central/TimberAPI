using Timberborn.DeconstructionSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class BuildingDeconstructionToolFactory(BuildingDeconstructionTool buildingDeconstructionTool) : IToolFactory
{
    public string Id => "BuildingDeconstructionTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        buildingDeconstructionTool.Initialize(toolGroup);
        return buildingDeconstructionTool;
    }
}