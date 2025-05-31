using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using Timberborn.PrefabSystem;
using Timberborn.Wonders;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public class PlaceableObjectToolGenerator(PrefabService prefabService) : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        foreach (var placeableBlockObject in prefabService.GetAll<PlaceableBlockObjectSpec>())
        {
            if (!placeableBlockObject.UsableWithCurrentFeatureToggles) continue;

            var labeledEntitySpec = placeableBlockObject.GetComponentFast<LabeledEntitySpec>();
            var prefab = placeableBlockObject.GetComponentFast<PrefabSpec>();
            var wonder = placeableBlockObject.GetComponentFast<WonderSpec>();
            
            var json = JsonConvert.SerializeObject(new
            {
                ToolSpec = new
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
                },
                PlaceableObjectToolSpec = new {
                    PrefabName = prefab.PrefabName 
                }
            });

            yield return new GeneratedSpec("Tools", $"Tool.{prefab.PrefabName}", json, true);
        }
    }
}