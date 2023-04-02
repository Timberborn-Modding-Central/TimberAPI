using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolSystem.Tools.PlaceableObjectTool
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
                var labeledPrefab = placeableBlockObject.GetComponent<LabeledPrefab>();
                var prefab = placeableBlockObject.GetComponent<Prefab>();

                var toolSpecification = new ToolSpecification<PlaceableObjectToolToolInformation>(
                    prefab.PrefabName,
                    placeableBlockObject.ToolGroupId,
                    "PlaceableObjectTool",
                    "brown",
                    placeableBlockObject.ToolOrder,
                    labeledPrefab.Image.name,
                    labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    false,
                    placeableBlockObject.DevModeTool,
                    new PlaceableObjectToolToolInformation(prefab.PrefabName)
                );

                _toolIconService.AddIcon(labeledPrefab.Image);

                yield return new GeneratedSpecification(JsonConvert.SerializeObject(toolSpecification), prefab.PrefabName, "ToolSpecification");
            }
        }
    }
}