using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.Fields;
using Timberborn.Planting;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolSystem.Tools.PlantingTool
{
    public class PlantingToolGenerator : IObjectSpecificationGenerator
    {
        private readonly ToolIconService _toolIconService;

        public PlantingToolGenerator(ToolIconService toolIconService)
        {
            _toolIconService = toolIconService;
        }

        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
        {
            var plantables = objectCollectionService.GetAllMonoBehaviours<Plantable>().ToList();
            for (var i = 0; i < plantables.Count; i++)
            {
                var plantable = plantables[i];
                var labeledPrefab = plantable.GetComponent<LabeledPrefab>();
                var prefab = plantable.GetComponent<Prefab>();

                var isCrop = plantable.GetComponent<Crop>() != null;

                var toolSpecification = new ToolSpecification<PlantingToolToolInformation>(
                    plantable.PrefabName,
                    isCrop ? "Fields" : "Forestry",
                    "PlantingTool",
                    "brown",
                    i * 10,
                    labeledPrefab.Image.name,
                    labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    false,
                    false,
                    new PlantingToolToolInformation(prefab.PrefabName)
                );

                _toolIconService.AddIcon(labeledPrefab.Image);

                yield return new GeneratedSpecification(JsonConvert.SerializeObject(toolSpecification), plantable.PrefabName, "ToolSpecification");
            }

            yield return CreateFieldsToolGroupSpecification();

            yield return CreateForestryPlantingToolGroupSpecification();
        }

        private GeneratedSpecification CreateFieldsToolGroupSpecification()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Fields",
                Layout = "Blue",
                Order = 30,
                NameLocKey = "ToolGroups.FieldsPlanting",
                Icon = "Sprites/BottomBar/FieldsPlantingToolGroupIcon",
                Section = "BottomBar",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "Fields", "ToolGroupSpecification");
        }

        private GeneratedSpecification CreateForestryPlantingToolGroupSpecification()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Forestry",
                Layout = "Blue",
                Order = 40,
                NameLocKey = "ToolGroups.ForestryPlanting",
                Icon = "Sprites/BottomBar/ForestryPlantingToolGroupIcon",
                Section = "BottomBar",
                DevModeTool = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "Fields", "ToolGroupSpecification");
        }
    }
}