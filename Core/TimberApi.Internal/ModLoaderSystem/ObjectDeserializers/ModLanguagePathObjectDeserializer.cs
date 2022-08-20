using System.Collections.Generic;
using TimberApi.Internal.Common;
using Timberborn.Persistence;

namespace TimberApi.Internal.ModLoaderSystem.ObjectDeserializers
{
    internal class ModLanguagePathObjectDeserializer : IObjectSerializer<ModAsset>
    {
        public void Serialize(ModAsset value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<ModAsset> Deserialize(IObjectLoader objectLoader)
        {
            string prefix = objectLoader.Get(new PropertyKey<string>("Prefix"));
            IEnumerable<string> scenes = objectLoader.Get(new ListKey<string>("Scenes"));
            string path = objectLoader.GetValueOrDefault(new PropertyKey<string>("Path"), "assets");
            return new ModAsset(prefix,scenes,path);
        }
    }
}