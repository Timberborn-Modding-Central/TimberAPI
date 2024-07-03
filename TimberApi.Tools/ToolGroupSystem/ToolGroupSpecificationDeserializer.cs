using System;
using TimberApi.Extensions;
using Timberborn.AssetSystem;
using Timberborn.Persistence;
using Timberborn.SerializationSystem;
using UnityEngine;

namespace TimberApi.Tools.ToolGroupSystem;

public class ToolGroupSpecificationDeserializer : IObjectSerializer<ToolGroupSpecification>
{
    private readonly IAssetLoader _assetLoader;

    protected ToolGroupSpecificationDeserializer(IAssetLoader assetLoader)
    {
        _assetLoader = assetLoader;
    }

    public void Serialize(ToolGroupSpecification value, IObjectSaver objectSaver)
    {
        throw new NotImplementedException();
    }

    public Obsoletable<ToolGroupSpecification> Deserialize(IObjectLoader objectLoader)
    {
        return new ToolGroupSpecification(
            objectLoader.Get(new PropertyKey<string>("Id")),
            objectLoader.GetValueOrDefault(new PropertyKey<string>("Type"), "ConstructionModeToolGroup"),
            objectLoader.Get(new PropertyKey<int>("Order")),
            objectLoader.Get(new PropertyKey<string>("NameLocKey")),
            _assetLoader.Load<Sprite>(objectLoader.Get(new PropertyKey<string>("Icon"))),
            objectLoader.GetValueOrDefault(new PropertyKey<bool>("FallbackGroup"), false),
            objectLoader.GetValueOrNull(new PropertyKey<string>("GroupId")),
            objectLoader.GetValueOrDefault(new PropertyKey<string>("Layout"), "Green"),
            objectLoader.GetValueOrDefault(new PropertyKey<string>("Section"), "BottomBar"),
            objectLoader.GetValueOrDefault(new PropertyKey<bool>("DevMode"), false),
            objectLoader.GetValueOrDefault(new PropertyKey<bool>("Hidden"), false),
            GetGroupInformationObjectSave(objectLoader)
        );
    }

    private static ObjectSave? GetGroupInformationObjectSave(IObjectLoader objectLoader)
    {
        if(! objectLoader.Has(new PropertyKey<ObjectSave>("GroupInformation")))
        {
            return null;
        }
            
        return ((ObjectLoader)objectLoader)._objectSave.Get<ObjectSave>("GroupInformation");
    }
}