using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TimberApi.SpecificationSystem;
using Timberborn.AssetSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecConvertGenerator(IAssetLoader assetLoader) : ISpecGenerator
{
    public IEnumerable<GeneratedSpec> Generate()
    {
        foreach (var toolGroupText in assetLoader.LoadAll<TextAsset>("Blueprints/ToolGroups").Where(asset => asset.Asset.name.ToLower().StartsWith("toolgroup.")))
        {
            var toolGroupSpec = JObject.Parse(toolGroupText.Asset.text)["ToolGroupSpec"];

            if (toolGroupSpec == null)
            {
                continue;
            }

            var json = JsonConvert.SerializeObject(new
            {
                TimberApiToolGroupSpec = new
                {
                    Id = toolGroupSpec["Id"],
                    Order = toolGroupSpec["Order"],
                    NameLocKey = toolGroupSpec["NameLocKey"],
                    Icon = toolGroupSpec["Icon"],
                    FallbackGroup = toolGroupSpec["FallbackGroup"],
                    DevMode = true,
                },
            });
            
            yield return new GeneratedSpec("ToolGroups", "TimberApi" + toolGroupText.Asset.name, json);
        }
    }
}