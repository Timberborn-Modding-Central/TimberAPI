using System;
using System.Linq;
using Timberborn.Localization;
using Timberborn.Persistence;
using Timberborn.Planting;
using Timberborn.PlantingUI;
using Timberborn.PrefabSystem;
using Timberborn.SelectionToolSystem;
using Timberborn.ToolSystem;

namespace TimberApi.ToolSystem.Tools.PlantingTool
{
    public class PlantingToolFactory : BaseToolFactory<PlantingToolToolInformation>
    {
        private readonly PlantableDescriber _plantableDescriber;
        private readonly PlantingSelectionService _plantingSelectionService;
        private readonly DevModePlantableSpawner _devModePlantableSpawner;
        private readonly SelectionToolProcessorFactory _selectionToolProcessorFactory;
        private readonly ILoc _loc;
        private readonly ObjectCollectionService _objectCollectionService;

        public PlantingToolFactory(
            PlantableDescriber plantableDescriber,
            PlantingSelectionService plantingSelectionService,
            DevModePlantableSpawner devModePlantableSpawner,
            SelectionToolProcessorFactory selectionToolProcessorFactory,
            ILoc loc,
            ObjectCollectionService objectCollectionService)
        {
            _plantableDescriber = plantableDescriber;
            _plantingSelectionService = plantingSelectionService;
            _devModePlantableSpawner = devModePlantableSpawner;
            _selectionToolProcessorFactory = selectionToolProcessorFactory;
            _loc = loc;
            _objectCollectionService = objectCollectionService;
        }

        public override string Id => "PlantingTool";

        public override Tool Create(ToolSpecification toolSpecification)
        {
            throw new NotSupportedException("PlantingTool requires a ToolGroup");
        }

        public override Tool Create(ToolSpecification toolSpecification, ToolGroup toolGroup)
        {
            var toolInformation = GetToolInformation(toolSpecification);
            var prefab = _objectCollectionService.GetAllMonoBehaviours<Prefab>().Single(o => o.IsNamed(toolInformation.PrefabName));
            var plantable = prefab.GetComponent<Plantable>();

            return new Timberborn.PlantingUI.PlantingTool(_plantableDescriber, _plantingSelectionService, _devModePlantableSpawner, _selectionToolProcessorFactory, plantable, GetPlanterBuildingName(plantable), toolGroup);
        }

        protected override PlantingToolToolInformation DeserializeToolInformation(IObjectLoader objectLoader)
        {
            return new PlantingToolToolInformation(objectLoader.Get(new PropertyKey<string>("PrefabName")));
        }

        private string GetPlanterBuildingName(Plantable plantable) => _loc.T(_objectCollectionService.GetAllMonoBehaviours<PlanterBuilding>()
            .Single((Func<PlanterBuilding, bool>) (building => building.PlantableResourceGroup == plantable.ResourceGroup)).GetComponent<LabeledPrefab>().DisplayNameLocKey);
    }
}