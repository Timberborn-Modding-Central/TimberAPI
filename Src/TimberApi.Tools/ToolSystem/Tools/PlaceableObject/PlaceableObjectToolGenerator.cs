using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.PrefabSystem;
using Timberborn.Wonders;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public class PlaceableObjectToolGenerator(PrefabService prefabService) : ISpecificationGenerator
{
    public IEnumerable<GeneratedSpecification> Generate()
    {
        foreach (var placeableBlockObject in prefabService.GetAll<PlaceableBlockObject>())
        {
            if (!placeableBlockObject.UsableWithCurrentFeatureToggles) continue;

            var labeledEntitySpec = placeableBlockObject.GetComponentFast<LabeledEntitySpec>();
            var prefab = placeableBlockObject.GetComponentFast<Prefab>();
            var wonder = placeableBlockObject.GetComponentFast<Wonder>();
            
            var json = JsonConvert.SerializeObject(new
            {
                Id = prefab.PrefabName,
                GroupId = placeableBlockObject.ToolGroupId,
                Type = "PlaceableObjectTool",
                Layout = !wonder ? "Default" : "WonderDefault",
                Order = placeableBlockObject.ToolOrder,
                Icon = labeledEntitySpec.ImagePath,
                NameLocKey = labeledEntitySpec.DisplayNameLocKey,
                labeledEntitySpec.DescriptionLocKey,
                Hidden = false,
                DevMode = placeableBlockObject.DevModeTool,
                ToolInformation = new
                {
                    prefab.PrefabName
                }
            });

            yield return new GeneratedSpecification("Tools", $"ToolSpecification.{prefab.PrefabName}", json, true);
        }
    }
}