using System;
using System.Linq;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.Persistence;
using Timberborn.Planting;
using Timberborn.PlantingUI;
using Timberborn.PrefabSystem;
using Timberborn.SelectionToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

public class PlantingToolFactory : BaseToolFactory<PlantingToolToolInformation>
{
    private readonly DevModePlantableSpawner _devModePlantableSpawner;

    private readonly ILoc _loc;

    private readonly PlantableDescriber _plantableDescriber;

    private readonly PlantingSelectionService _plantingSelectionService;

    private readonly PrefabService _prefabService;

    private readonly SelectionToolProcessorFactory _selectionToolProcessorFactory;

    private readonly ToolUnlockingService _toolUnlockingService;

    public PlantingToolFactory(
        PlantableDescriber plantableDescriber,
        PlantingSelectionService plantingSelectionService,
        DevModePlantableSpawner devModePlantableSpawner,
        SelectionToolProcessorFactory selectionToolProcessorFactory,
        ILoc loc,
        PrefabService prefabService,
        ToolUnlockingService toolUnlockingService)
    {
        _plantableDescriber = plantableDescriber;
        _plantingSelectionService = plantingSelectionService;
        _devModePlantableSpawner = devModePlantableSpawner;
        _selectionToolProcessorFactory = selectionToolProcessorFactory;
        _loc = loc;
        _prefabService = prefabService;
        _toolUnlockingService = toolUnlockingService;
    }

    public override string Id => "PlantingTool";

    protected override Tool CreateTool(ToolSpecification toolSpecification, PlantingToolToolInformation toolInformation,
        ToolGroup? toolGroup)
    {
        var prefab = _prefabService.GetAll<Prefab>()
            .First(o => o.IsNamedExactly(toolInformation.PrefabName));
        var plantable = prefab.GetComponentFast<Plantable>();

        return new PlantingTool(
            _plantableDescriber,
            _plantingSelectionService,
            _devModePlantableSpawner,
            _toolUnlockingService,
            _selectionToolProcessorFactory,
            plantable,
            GetPlanterBuildingName(plantable),
            toolGroup);
    }

    protected override PlantingToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
    {
        return new PlantingToolToolInformation(objectLoader.Get(new PropertyKey<string>("PrefabName")));
    }
    
    private string GetPlanterBuildingName(Plantable plantable)
    {
        return _loc.T(_prefabService.GetAll<PlanterBuildingSpec>().Single((Func<PlanterBuildingSpec, bool>) (building => building.PlantableResourceGroup == plantable.ResourceGroup)).GetComponentFast<LabeledEntitySpec>().DisplayNameLocKey);
    }
}