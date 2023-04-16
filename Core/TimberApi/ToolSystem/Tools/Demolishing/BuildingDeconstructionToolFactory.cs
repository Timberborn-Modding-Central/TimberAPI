using Timberborn.DeconstructionSystemUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.Demolishing
{
    public class BuildingDeconstructionToolFactory : IToolFactory
    {
        private readonly BuildingDeconstructionTool _buildingDeconstructionTool;

        public BuildingDeconstructionToolFactory(BuildingDeconstructionTool buildingDeconstructionTool)
        {
            _buildingDeconstructionTool = buildingDeconstructionTool;
        }

        public string Id => "BuildingDeconstructionTool";

        public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
        {
            _buildingDeconstructionTool.Initialize(toolGroup);
            return _buildingDeconstructionTool;
        }
    }
}