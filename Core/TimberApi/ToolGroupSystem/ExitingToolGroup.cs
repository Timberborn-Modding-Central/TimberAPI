using Timberborn.ConstructionMode;
using Timberborn.PlantingUI;
using Timberborn.ToolSystem;

namespace TimberApi.ToolGroupSystem
{
    /// <summary>
    /// Add all mode enablers in this class to deactivate them on exiting a group
    /// </summary>
    public class ExitingTool : ToolGroup, IConstructionModeEnabler, IPlantingToolGroup
    {
    }
}