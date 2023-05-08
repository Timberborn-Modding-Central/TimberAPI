using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.Fields;
using Timberborn.NaturalResources;
using Timberborn.Planting;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolSystem.Tools.Planting
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
            foreach (var plantable in plantables)
            {
                var labeledPrefab = plantable.GetComponentFast<LabeledPrefab>();
                var prefab = plantable.GetComponentFast<Prefab>();

                var isCrop = plantable.GetComponentFast<Crop>() != null;
                var naturalResource = plantable.GetComponentFast<NaturalResource>();

                var json = JsonConvert.SerializeObject(new
                {
                    Id = plantable.PrefabName,
                    GroupId = isCrop ? "Fields" : "Forestry",
                    Type = "PlantingTool",
                    Layout = "Default",
                    Order = naturalResource.OrderId,
                    Icon = $"{prefab.PrefabName}:{labeledPrefab.Image.name}",
                    NameLocKey = labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    Hidden = false,
                    DevMode = false,
                    ToolInformation = new
                    {
                        prefab.PrefabName
                    }
                });

                _toolIconService.AddIcon($"{prefab.PrefabName}:{labeledPrefab.Image.name}", labeledPrefab.Image);

                yield return new GeneratedSpecification(json, plantable.PrefabName, "ToolSpecification");
            }

            yield return CreateFieldsToolGroupSpecification();

            yield return CreateForestryPlantingToolGroupSpecification();
        }

        private static GeneratedSpecification CreateFieldsToolGroupSpecification()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Fields",
                Layout = "Blue",
                Order = 20,
                Type = "PlantingModeToolGroup",
                NameLocKey = "ToolGroups.FieldsPlanting",
                Icon = "Sprites/BottomBar/FieldsPlantingToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });


            return new GeneratedSpecification(json, "Fields", "ToolGroupSpecification");
        }

        private static GeneratedSpecification CreateForestryPlantingToolGroupSpecification()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Forestry",
                Layout = "Blue",
                Order = 30,
                Type = "PlantingModeToolGroup",
                NameLocKey = "ToolGroups.ForestryPlanting",
                Icon = "Sprites/BottomBar/ForestryPlantingToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "Forestry", "ToolGroupSpecification");
        }
    }
}