using TimberApi.Common.Extensions;
using Timberborn.Persistence;

namespace TimberApi.Core.ModLoaderSystem.ObjectDeserializers
{
    public class SpecificationDirectoryDeserializer : IObjectSerializer<SpecificationDirectory>
    {
        public void Serialize(SpecificationDirectory value, IObjectSaver objectSaver)
        {
        }

        public Obsoletable<SpecificationDirectory> Deserialize(IObjectLoader objectLoader)
        {
            var path = objectLoader.Get(new PropertyKey<string>("Path"));
            var requiredDependencies = objectLoader.GetValueOrEmpty(new ListKey<string>("RequiredDependencies"));

            return new SpecificationDirectory(path, requiredDependencies);
        }
    }
}