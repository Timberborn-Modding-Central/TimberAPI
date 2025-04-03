using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.EntitySystem;
using Timberborn.Fields;
using Timberborn.NaturalResources;
using Timberborn.Planting;
using Timberborn.PrefabSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem.Tools.Planting;

public class PlantingToolGenerator(PrefabService prefabService) : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        var plantables = prefabService.GetAll<PlantableSpec>().ToList();
        
        foreach (var plantable in plantables)
        {
            var labeledEntitySpec = plantable.GetComponentFast<LabeledEntitySpec>();
            
            var prefab = plantable.GetComponentFast<PrefabSpec>();

            var isCrop = plantable.GetComponentFast<CropSpec>() != null;
            var naturalResource = plantable.GetComponentFast<NaturalResourceSpec>();
            
            var json = JsonConvert.SerializeObject(new
            {
                ToolSpec = new
                {
                    Id = plantable.PrefabName,
                    GroupId = isCrop ? "Fields" : "Forestry",
                    Type = "PlantingTool",
                    Layout = "Default",
                    Order = naturalResource.Order,
                    Icon = labeledEntitySpec.ImagePath,
                    NameLocKey = labeledEntitySpec.DisplayNameLocKey,
                    labeledEntitySpec.DescriptionLocKey,
                    Hidden = false,
                    DevMode = false,
                },
                PlantingToolSpec = new {
                    PrefabName = prefab.PrefabName 
                }
            });

            yield return new GeneratedSpec("Tools", $"Tool.{plantable.PrefabName}", json, true);
        }

        yield return CreateFieldsToolGroupSpecification();

        yield return CreateForestryPlantingToolGroupSpecification();
    }

    private static GeneratedSpec CreateFieldsToolGroupSpecification()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Id = "Fields",
                Order = 20,
                NameLocKey = "ToolGroups.FieldsPlanting",
                Icon = "Sprites/BottomBar/FieldsPlantingToolGroupIcon",
                FallbackGroup = false,
                Type = "PlantingModeToolGroup",
                Layout = "Blue",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
            BottomBarSpec = new
            {
                Section = 0,
            }
        });


        return new GeneratedSpec("ToolGroups", "TimberApiToolGroups.Fields", json);
    }

    private static GeneratedSpec CreateForestryPlantingToolGroupSpecification()
    {
        var json = JsonConvert.SerializeObject(new
        {
            TimberApiToolGroupSpec = new
            {
                Id = "Forestry",
                Order = 30,
                NameLocKey = "ToolGroups.ForestryPlanting",
                Icon = "Sprites/BottomBar/ForestryPlantingToolGroupIcon",
                FallbackGroup = false,
                Type = "PlantingModeToolGroup",
                Layout = "Blue",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
            },
            BottomBarSpec = new
            {
                Section = 0,
            }
        });

        return new GeneratedSpec("ToolGroups", "TimberApiToolGroups.Forestry", json);
    }
}