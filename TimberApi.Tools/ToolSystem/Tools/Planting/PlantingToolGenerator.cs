using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.EntitySystem;
using Timberborn.Fields;
using Timberborn.NaturalResources;
using Timberborn.Planting;
using Timberborn.PrefabSystem;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

public class PlantingToolGenerator : ISpecificationGenerator
{
    private readonly PrefabService _prefabService;

    public PlantingToolGenerator(PrefabService prefabService)
    {
        _prefabService = prefabService;
    }

    public IEnumerable<GeneratedSpecification> Generate()
    {
        var plantables = _prefabService.GetAll<Plantable>().ToList();
        
        foreach (var plantable in plantables)
        {
            var labeledEntitySpec = plantable.GetComponentFast<LabeledEntitySpec>();
            
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
                Icon = labeledEntitySpec.ImagePath,
                NameLocKey = labeledEntitySpec.DisplayNameLocKey,
                labeledEntitySpec.DescriptionLocKey,
                Hidden = false,
                DevMode = false,
                ToolInformation = new
                {
                    prefab.PrefabName
                }
            });

            yield return new GeneratedSpecification("Tools", $"ToolSpecification.{plantable.PrefabName}", json, true);
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


        return new GeneratedSpecification("Tools", "ToolGroupSpecification.Fields", json);
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

        return new GeneratedSpecification("Tools", "ToolGroupSpecification.Forestry", json);
    }
}