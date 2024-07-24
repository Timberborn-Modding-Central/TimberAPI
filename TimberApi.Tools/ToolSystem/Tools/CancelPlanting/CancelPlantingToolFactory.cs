using Timberborn.Localization;
using Timberborn.PlantingUI;
using Timberborn.SelectionToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.CancelPlanting;

public class CancelPlantingToolFactory : IToolFactory
{
    private readonly ILoc _loc;

    private readonly PlantingSelectionService _plantingSelectionService;

    private readonly SelectionToolProcessorFactory _selectionToolProcessorFactory;

    public CancelPlantingToolFactory(PlantingSelectionService plantingSelectionService, ILoc loc,
        SelectionToolProcessorFactory selectionToolProcessorFactory)
    {
        _plantingSelectionService = plantingSelectionService;
        _loc = loc;
        _selectionToolProcessorFactory = selectionToolProcessorFactory;
    }

    public string Id => "CancelPlantingTool";

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup = null)
    {
        return new CancelPlantingTool(_plantingSelectionService, _loc, _selectionToolProcessorFactory, toolGroup);
    }
}