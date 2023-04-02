using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using TimberApi.ToolGroupSystem;
using Timberborn.AssetSystem;
using Timberborn.Planting;
using Timberborn.PrefabSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace TimberApi.ToolSystem.Tools.PlantingTool
{
    public class PlantingToolGenerator : IObjectSpecificationGenerator
    {
        private readonly ToolIconService _toolIconService;

        private readonly IResourceAssetLoader _resourceAssetLoader;

        public PlantingToolGenerator(ToolIconService toolIconService, IResourceAssetLoader resourceAssetLoader)
        {
            _toolIconService = toolIconService;
            _resourceAssetLoader = resourceAssetLoader;
        }

        public IEnumerable<ISpecification> Generate(ObjectCollectionService objectCollectionService)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var plantables = objectCollectionService.GetAllMonoBehaviours<Plantable>().ToList();
            for (int i = 0; i < plantables.Count; i++)
            {
                var plantable = plantables[i];
                var labeledPrefab = plantable.GetComponent<LabeledPrefab>();
                var prefab = plantable.GetComponent<Prefab>();

                var toolSpecification = new ToolSpecification<PlantingToolToolInformation>(
                    plantable.PrefabName,
                    "Fields",
                    "PlantingTool",
                    "brown",
                    i * 10,
                    labeledPrefab.Image.name,
                    labeledPrefab.DisplayNameLocKey,
                    labeledPrefab.DescriptionLocKey,
                    false,
                    false,
                    new PlantingToolToolInformation(prefab.PrefabName)
                );

                _toolIconService.AddIcon(labeledPrefab.Image);

                yield return new GeneratedSpecification(JsonConvert.SerializeObject(toolSpecification), plantable.PrefabName, "ToolSpecification");
            }

            yield return CreateToolGroupSpecification();

            stopwatch.Stop();
            Debug.LogWarning($"Time execution PlantableToolGenerator: {stopwatch.ElapsedMilliseconds}");
        }

        private GeneratedSpecification CreateToolGroupSpecification()
        {
            var fieldsPlantingToolGroupIcon = _resourceAssetLoader.Load<Sprite>("Sprites/BottomBar/FieldsPlantingToolGroupIcon");

            _toolIconService.AddIcon(fieldsPlantingToolGroupIcon);

            var toolGroupSpecification = new ToolGroupSpecification(
                "Fields",
                null,
                "blue",
                30,
                "ToolGroups.FieldsPlanting",
                _resourceAssetLoader.Load<Sprite>("Sprites/BottomBar/FieldsPlantingToolGroupIcon"),
                "0",
                false,
                false,
                false);

            return new GeneratedSpecification(JsonConvert.SerializeObject(toolGroupSpecification), "Fields", "ToolGroupSpecification");
        }
    }
}