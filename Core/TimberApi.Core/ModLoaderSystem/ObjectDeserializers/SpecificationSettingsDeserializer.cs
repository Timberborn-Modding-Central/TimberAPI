using TimberApi.Common.Extensions;
using Timberborn.Persistence;

namespace TimberApi.Core.ModLoaderSystem.ObjectDeserializers
{
    public class SpecificationSettingsDeserializer : IObjectSerializer<SpecificationSettings>
    {
        private readonly SpecificationDirectoryDeserializer _specificationDirectoryDeserializer;

        public SpecificationSettingsDeserializer(SpecificationDirectoryDeserializer specificationDirectoryDeserializer)
        {
            _specificationDirectoryDeserializer = specificationDirectoryDeserializer;
        }

        public void Serialize(SpecificationSettings value, IObjectSaver objectSaver)
        {
        }

        public Obsoletable<SpecificationSettings> Deserialize(IObjectLoader objectLoader)
        {
            var basePath = objectLoader.GetValueOrDefault(new PropertyKey<string>("BasePath"), "specifications");
            var specificationDirectories = objectLoader.GetValueOrEmpty(new ListKey<SpecificationDirectory>("Directories"), _specificationDirectoryDeserializer);

            return new SpecificationSettings(basePath, specificationDirectories);
        }
    }
    
    
}