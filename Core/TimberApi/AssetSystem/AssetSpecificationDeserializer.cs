using System.Collections.Immutable;
using TimberApi.Common.Extensions;
using Timberborn.Persistence;

namespace TimberApi.AssetSystem
{
    public class AssetSpecificationDeserializer : IObjectSerializer<AssetSpecification>
    {
        public void Serialize(AssetSpecification value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<AssetSpecification> Deserialize(IObjectLoader objectLoader)
        {
            return new AssetSpecification(
                objectLoader.GetValueOrEmpty(new ListKey<string>("IgnoreDirectoryPrefixes")).ToImmutableArray()
            );
        }
    }
}