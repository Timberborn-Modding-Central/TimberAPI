using Timberborn.DeconstructionSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Demolishing;

public class BuildingDeconstructionToolFactory : IToolFactory
{
    public string Id => "BuildingDeconstructionTool";

    private readonly BuildingDeconstructionTool _buildingDeconstructionTool;

    public BuildingDeconstructionToolFactory(BuildingDeconstructionTool buildingDeconstructionTool)
    {
        _buildingDeconstructionTool = buildingDeconstructionTool;
    }
        
    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        _buildingDeconstructionTool.Initialize(toolGroup);
        return _buildingDeconstructionTool;
    }
}