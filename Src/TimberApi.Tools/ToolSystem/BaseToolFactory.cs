using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SerializationSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolSystem;

public abstract class BaseToolFactory<T> : IToolFactory
{
    public abstract string Id { get; }

    public Tool Create(ToolSpecification toolSpecification, ToolGroup? toolGroup)
    {
        return CreateTool(toolSpecification, GetToolInformation(toolSpecification), toolGroup);
    }

    protected abstract Tool CreateTool(ToolSpecification toolSpecification, T toolInformation, ToolGroup? toolGroup);

    private T GetToolInformation(ToolSpecification toolSpecification)
    {
        var objectLoader = ObjectLoader.CreateBasicLoader(toolSpecification.ToolInformation);

        return DeserializeToolInformation(objectLoader);
    }

    protected abstract T DeserializeToolInformation(IObjectLoader objectLoader);
}

public class SpecificationService(
    ObjectSaveReaderWriter objectSaveReaderWriter,
    IAssetLoader assetLoader)
    : ISpecificationService
{
    public static readonly string SpecificationPath = "Specifications";
    public static readonly string OptionalSpecificationSuffix = ".optional";
    public readonly IAssetLoader _assetLoader = assetLoader;
    public readonly ObjectSaveReaderWriter _objectSaveReaderWriter = objectSaveReaderWriter;

    static SpecificationService()
    {
    }

    public IEnumerable<T> GetSpecifications<T>(IObjectSerializer<T> serializer)
    {
        var type = typeof(T).Name;
        foreach (var source in _assetLoader.LoadAll<TextAsset>(SpecificationPath)
                     .Select((Func<LoadedAsset<TextAsset>, TextAsset>)(loadedAsset => loadedAsset.Asset))
                     .Where((Func<TextAsset, bool>)(asset => asset.name.StartsWith(type + ".")))
                     .GroupBy((Func<TextAsset, string>)(asset =>
                         asset.name.Replace(OptionalSpecificationSuffix, string.Empty)))
                     .Where<IGrouping<string, TextAsset>>((Func<IGrouping<string, TextAsset>, bool>)(assetGroup =>
                         assetGroup.Any((Func<TextAsset, bool>)(asset =>
                             !asset.name.EndsWith(OptionalSpecificationSuffix))))))
            yield return ObjectLoader
                .CreateBasicLoader(_objectSaveReaderWriter
                    .ReadJsons(source.Select((Func<TextAsset, string>)(asset => asset.text))).Wrap(type))
                .Get(new PropertyKey<T>(type), serializer);
    }
}