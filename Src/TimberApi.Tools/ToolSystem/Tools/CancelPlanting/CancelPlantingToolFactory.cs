using Timberborn.Localization;
using Timberborn.PlantingUI;
using Timberborn.SelectionToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

public class CancelPlantingToolFactory(
    PlantingSelectionService plantingSelectionService,
    ILoc loc,
    SelectionToolProcessorFactory selectionToolProcessorFactory)
    : IToolFactory
{
    public string Id => "CancelPlantingTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return new CancelPlantingTool(plantingSelectionService, loc, selectionToolProcessorFactory, toolGroup);
    }
}