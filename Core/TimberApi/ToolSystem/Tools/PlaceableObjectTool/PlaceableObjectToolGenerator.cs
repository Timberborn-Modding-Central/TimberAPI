using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.BlockSystem;
using Timberborn.PrefabSystem;
using Debug = UnityEngine.Debug;

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
            Debug.LogError(objectCollectionService.GetAllMonoBehaviours<PlaceableBlockObject>().Count());
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var placeableBlockObject in objectCollectionService.GetAllMonoBehaviours<PlaceableBlockObject>())
            {
                var labeledPrefab = placeableBlockObject.GetComponent<LabeledPrefab>();
                var prefab = placeableBlockObject.GetComponent<Prefab>();
                // Debug.LogWarning(prefab.IsNamed(prefab.PrefabName));

                var toolSpecification = new ToolSpecification<PlaceableObjectToolToolInformation>(
                    prefab.PrefabName,
                    placeableBlockObject.ToolGroupId,
                    "PlaceableObjectTool",
                    "blue",
                    placeableBlockObject.ToolOrder,
                    labeledPrefab.Image.name,
                    labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    placeableBlockObject.DevModeTool,
                    new PlaceableObjectToolToolInformation(prefab.PrefabName)
                );

                _toolIconService.AddIcon(labeledPrefab.Image);

                Debug.LogWarning(JsonConvert.SerializeObject(toolSpecification));


                yield return new GeneratedSpecification(JsonConvert.SerializeObject(toolSpecification), placeableBlockObject.name, "ToolSpecification");
            }

            stopwatch.Stop();
            Debug.LogWarning($"Time execution PlaceableObjectToolGenerator: {stopwatch.ElapsedMilliseconds}");
        }
    }
}