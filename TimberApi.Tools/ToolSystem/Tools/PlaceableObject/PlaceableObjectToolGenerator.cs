using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;
using Timberborn.Wonders;

namespace TimberApi.Tools.ToolSystem.Tools.PlaceableObject;

public class PlaceableObjectToolGenerator : ISpecificationGenerator
{
    private readonly PrefabService _prefabService;
    private readonly ToolIconService _toolIconService;

    public PlaceableObjectToolGenerator(ToolIconService toolIconService, PrefabService prefabService)
    {
        _toolIconService = toolIconService;
        _prefabService = prefabService;
    }

    public IEnumerable<GeneratedSpecification> Generate()
    {
        foreach (var placeableBlockObject in _prefabService.GetAllMonoBehaviours<PlaceableBlockObject>())
        {
            if (!placeableBlockObject.UsableWithCurrentFeatureToggles) continue;

            var labeledPrefab = placeableBlockObject.GetComponentFast<LabeledPrefab>();
            var prefab = placeableBlockObject.GetComponentFast<Prefab>();
            var wonder = placeableBlockObject.GetComponentFast<Wonder>();

            _toolIconService.AddIcon($"{prefab.PrefabName}:{labeledPrefab.Image.name}", labeledPrefab.Image);

            var json = JsonConvert.SerializeObject(new
            {
                Id = prefab.PrefabName,
                GroupId = placeableBlockObject.ToolGroupId,
                Type = "PlaceableObjectTool",
                Layout = !wonder ? "Default" : "WonderDefault",
                Order = placeableBlockObject.ToolOrder,
                Icon = $"{prefab.PrefabName}:{labeledPrefab.Image.name}",
                NameLocKey = labeledPrefab.DisplayNameLocKey,
                labeledPrefab.DescriptionLocKey,
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