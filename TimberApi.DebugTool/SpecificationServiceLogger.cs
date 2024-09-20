using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SerializationSystem;
using UnityEngine;

namespace TimberApi.DebugTool;

public class SpecificationServiceLogger : SpecificationService, ISpecificationService
{
    public SpecificationServiceLogger(ObjectSaveReaderWriter objectSaveReaderWriter, IAssetLoader assetLoader) : base(objectSaveReaderWriter, assetLoader)
    {
    }

    public new IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
    {

            var type = typeof (T).Name;

            var specifications = new List<T>();
            
            foreach (var source in _assetLoader.LoadAll<TextAsset>(SpecificationPath)
                         .Select(loadedAsset => loadedAsset.Asset)
                         .Where(asset => asset.name.StartsWith(type + "."))
                         .GroupBy(asset => asset.name.Replace(OptionalSpecificationSuffix, string.Empty))
                         .Where(assetGroup => assetGroup.Any(asset => !asset.name.EndsWith(OptionalSpecificationSuffix))))
            {
                try
                {
                    specifications.Add(ObjectLoader.CreateBasicLoader(_objectSaveReaderWriter.ReadJsons(source.Select(asset => asset.text)).Wrap(type)).Get(new PropertyKey<T>(type), serializer));
                }
                catch (Exception e)
                {
                    var test = source.Join(asset => $"{asset.name}.json", ", ");
                    Debug.LogError($"Something went wrong deserializing specification file: {test}");
                    throw;
                }
            }

            return specifications;
    }
}