using Timberborn.ConstructionMode;
using Timberborn.ForestryUI;
using Timberborn.PlantingUI;

namespace TimberApi.ToolGroupSystem
{
    /// <summary>
    ///     Add all mode enablers in this class to deactivate them on exiting a group
    /// </summary>
    public class ExitingTool : TreeCuttingAreaToolGroup, IConstructionModeEnabler, IPlantingToolGroup
    {
    }
}