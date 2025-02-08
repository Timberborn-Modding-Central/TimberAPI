using System;
using System.Linq;
using Timberborn.BlueprintSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.MortalSystem;
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
    : IToolFactory
{
    public string Id => "PlantingTool";
    
    public Tool Create(ToolSpec toolSpec, ToolGroup? toolGroup = null)
    {
        var plantingToolSpec = toolSpec.GetSpec<PlantingToolSpec>();
        
        var prefab = prefabService.GetAll<PrefabSpec>().First(o => o.IsNamedExactly(plantingToolSpec.PrefabName));
        
        var plantable = prefab.GetComponentFast<PlantableSpec>();

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
    
    private string GetPlanterBuildingName(PlantableSpec plantable)
    {
        return loc.T(prefabService.GetAll<PlanterBuildingSpec>().Single((Func<PlanterBuildingSpec, bool>) (building => building.PlantableResourceGroup == plantable.ResourceGroup)).GetComponentFast<LabeledEntitySpec>().DisplayNameLocKey);
    }
}