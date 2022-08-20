using TimberApi.Internal.Common;
using TimberApiVersioning;
using Timberborn.Persistence;

namespace TimberApi.Internal.ModLoaderSystem.ObjectDeserializers
{
    internal class ModDependencyObjectDeserializer : IObjectSerializer<ModDependency>
    {
        public void Serialize(ModDependency value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<ModDependency> Deserialize(IObjectLoader objectLoader)
        {
            string uniqueId = objectLoader.Get(new PropertyKey<string>("UniqueId"));
            Version minimumVersion = Version.Parse(objectLoader.Get(new PropertyKey<string>("MinimumVersion")));
            bool optional = objectLoader.GetValueOrDefault(new PropertyKey<bool>("Optional"), false);
            return new ModDependency(uniqueId, minimumVersion, optional);
        }
    }
}