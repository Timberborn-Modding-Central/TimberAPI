using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using TimberApi.ToolSystem;
using TimberApi.ToolSystem.Factories.PlaceableObjectTool;
using Timberborn.AssetSystem;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;

namespace TimberApi.ToolGroupSystem
{
    public class ToolGroupGenerator : ISpecificationGenerator
    {
        private readonly ResourceAssetLoader _resourceAssetLoader;

        public ToolGroupGenerator(ResourceAssetLoader resourceAssetLoader)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        public IEnumerable<ISpecification> Generate()
        {
            foreach (var placeableBlockObject in _resourceAssetLoader.LoadAll<PlaceableBlockObject>(""))
            {
                var labeledPrefab = placeableBlockObject.GetComponent<LabeledPrefab>();

                var test = new ToolSpecification<PlaceableObjectToolToolInformation>(
                    placeableBlockObject.name,
                    "PlaceableObjectTool",
                    "blue",
                    placeableBlockObject.ToolOrder,
                    $"buildings/{placeableBlockObject.ToolGroupId}/{placeableBlockObject.name}/{placeableBlockObject.name}Icon",
                    labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    placeableBlockObject.DevModeTool,
                    new PlaceableObjectToolToolInformation()
                );

                yield return new GeneratedSpecification(JsonConvert.SerializeObject(test), placeableBlockObject.name, "ToolSpecification");
            }
        }
    }
}