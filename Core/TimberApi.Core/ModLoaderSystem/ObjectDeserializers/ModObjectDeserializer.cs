using System.Collections.Generic;
using System.IO;
using TimberApi.Core.Common;
using TimberApi.Core2.ModSystem;
using TimberApiVersioning;
using Timberborn.Persistence;

namespace TimberApi.Core.ModLoaderSystem.ObjectDeserializers
{
    internal class ModObjectDeserializer : IObjectSerializer<Mod>
    {
        private readonly ModDependencyObjectDeserializer _modDependencyObjectDeserializer;

        private readonly ModAssetInfoObjectDeserializer _modAssetInfoInfoObjectDeserializer;

        public ModObjectDeserializer(ModDependencyObjectDeserializer modDependencyObjectDeserializer, ModAssetInfoObjectDeserializer modAssetInfoInfoObjectDeserializer)
        {
            _modDependencyObjectDeserializer = modDependencyObjectDeserializer;
            _modAssetInfoInfoObjectDeserializer = modAssetInfoInfoObjectDeserializer;
        }

        public void Serialize(Mod value, IObjectSaver objectSaver)
        {
            throw new System.NotImplementedException();
        }

        public Obsoletable<Mod> Deserialize(IObjectLoader objectLoader)
        {
            string name = objectLoader.Get(new PropertyKey<string>("Name"));
            Version version = Version.Parse(objectLoader.Get(new PropertyKey<string>("Version")));
            string uniqueId = objectLoader.Get(new PropertyKey<string>("UniqueId"));
            Version minimumApiVersion = Version.Parse(objectLoader.Get(new PropertyKey<string>("MinimumApiVersion")));
            Version minimumGameVersion = Version.Parse(objectLoader.Get(new PropertyKey<string>("MinimumGameVersion")));

            string entryDll = objectLoader.GetValueOrDefault(new PropertyKey<string>("EntryDll"), "");
            string specificationPath = PathToCrossPlatformPath(objectLoader.GetValueOrDefault(new PropertyKey<string>("SpecificationPath"), "specifications"));
            string languagePath = PathToCrossPlatformPath(objectLoader.GetValueOrDefault(new PropertyKey<string>("LanguagePath"), "lang"));
            IEnumerable<IModAssetInfo> assets = objectLoader.GetValueOrEmpty(new ListKey<ModAssetInfo>("Assets"), _modAssetInfoInfoObjectDeserializer);
            IEnumerable<ModDependency> modDependencies = objectLoader.GetValueOrEmpty(new ListKey<ModDependency>("Dependencies"), _modDependencyObjectDeserializer);
            return new Mod(name, version, uniqueId, minimumApiVersion, minimumGameVersion, entryDll, specificationPath, languagePath, assets, modDependencies);
        }

        private static string PathToCrossPlatformPath(string path)
        {
            return Path.Combine(path.Split("/"));
        }
    }
}