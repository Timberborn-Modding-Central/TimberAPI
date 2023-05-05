using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolSystem.Tools.PlaceableObject
{
    public class PlaceableObjectToolGenerator : IObjectSpecificationGenerator
    {
        private readonly ToolIconService _toolIconService;

        public PlaceableObjectToolGenerator(ToolIconService toolIconService)
        {
            _toolIconService = toolIconService;
        }

        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
        {
            foreach (var placeableBlockObject in objectCollectionService.GetAllMonoBehaviours<PlaceableBlockObject>())
            {
                if(! placeableBlockObject.UsableWithCurrentFeatureToggles)
                {
                    continue;
                }
                
                var labeledPrefab = placeableBlockObject.GetComponentFast<LabeledPrefab>();
                var prefab = placeableBlockObject.GetComponentFast<Prefab>();
                var json = JsonConvert.SerializeObject(new
                {
                    Id = prefab.PrefabName,
                    GroupId = placeableBlockObject.ToolGroupId,
                    Type = "PlaceableObjectTool",
                    Layout = "Default",
                    Order = placeableBlockObject.ToolOrder * 10,
                    Icon = labeledPrefab.Image.name,
                    NameLocKey = labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    Hidden = false,
                    placeableBlockObject.DevModeTool,
                    FallbackGroup = false,
                    ToolInformation = new
                    {
                        prefab.PrefabName
                    }
                });

                _toolIconService.AddIcon(labeledPrefab.Image);

                yield return new GeneratedSpecification(json, prefab.PrefabName, "ToolSpecification");
            }
        }
    }
}