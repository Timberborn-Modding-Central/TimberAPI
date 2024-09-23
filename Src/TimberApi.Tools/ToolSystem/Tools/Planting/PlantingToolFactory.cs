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

public class PlantingToolFactory(
    PlantableDescriber plantableDescriber,
    PlantingSelectionService plantingSelectionService,
    DevModePlantableSpawner devModePlantableSpawner,
    SelectionToolProcessorFactory selectionToolProcessorFactory,
    ILoc loc,
    PrefabService prefabService,
    ToolUnlockingService toolUnlockingService)
    : BaseToolFactory<PlantingToolToolInformation>
{
    public override string Id => "PlantingTool";

    protected override Tool CreateTool(ToolSpecification toolSpecification, PlantingToolToolInformation toolInformation,
        ToolGroup? toolGroup)
    {
        var prefab = prefabService.GetAll<Prefab>()
            .First(o => o.IsNamedExactly(toolInformation.PrefabName));
        var plantable = prefab.GetComponentFast<Plantable>();

        return new PlantingTool(
            plantableDescriber,
            plantingSelectionService,
            devModePlantableSpawner,
            toolUnlockingService,
            selectionToolProcessorFactory,
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
        return loc.T(prefabService.GetAll<PlanterBuildingSpec>().Single((Func<PlanterBuildingSpec, bool>) (building => building.PlantableResourceGroup == plantable.ResourceGroup)).GetComponentFast<LabeledEntitySpec>().DisplayNameLocKey);
    }
}