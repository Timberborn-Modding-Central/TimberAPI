using System;
using TimberApi.Common.Extensions;
using Timberborn.Persistence;
using Version = TimberApi.New.VersionSystem.Version;

namespace TimberApi.Core.ModLoaderSystem.ObjectDeserializers
{
    internal class ModDependencyObjectDeserializer : IObjectSerializer<ModDependency>
    {
        public void Serialize(ModDependency value, IObjectSaver objectSaver)
        {
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