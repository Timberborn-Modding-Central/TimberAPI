using System.Collections.Generic;
using System.IO;
using TimberApi.Common.Extensions;
using TimberApi.ModSystem;
using TimberApi.VersionSystem;
using Timberborn.Persistence;

namespace TimberApi.Core.ModLoaderSystem.ObjectDeserializers
{
    internal class ModObjectDeserializer : IObjectSerializer<Mod>
    {
        private readonly ModAssetInfoObjectDeserializer _modAssetInfoInfoObjectDeserializer;
        
        private readonly ModDependencyObjectDeserializer _modDependencyObjectDeserializer;

        private readonly SpecificationSettingsDeserializer _specificationSettingsDeserializer;

        public ModObjectDeserializer(ModDependencyObjectDeserializer modDependencyObjectDeserializer, ModAssetInfoObjectDeserializer modAssetInfoInfoObjectDeserializer, SpecificationSettingsDeserializer specificationSettingsDeserializer)
        {
            _modDependencyObjectDeserializer = modDependencyObjectDeserializer;
            _modAssetInfoInfoObjectDeserializer = modAssetInfoInfoObjectDeserializer;
            _specificationSettingsDeserializer = specificationSettingsDeserializer;
        }

        public void Serialize(Mod value, IObjectSaver objectSaver)
        {
        }

        public Obsoletable<Mod> Deserialize(IObjectLoader objectLoader)
        {
            var name = objectLoader.Get(new PropertyKey<string>("Name"));
            var version = Version.Parse(objectLoader.Get(new PropertyKey<string>("Version")));
            var uniqueId = objectLoader.Get(new PropertyKey<string>("UniqueId"));
            var minimumApiVersion = Version.Parse(objectLoader.Get(new PropertyKey<string>("MinimumApiVersion")));
            var minimumGameVersion = Version.Parse(objectLoader.Get(new PropertyKey<string>("MinimumGameVersion")));

            var entryDll = objectLoader.GetValueOrDefault(new PropertyKey<string>("EntryDll"), "");
            var specificationPath = PathToCrossPlatformPath(objectLoader.GetValueOrDefault(new PropertyKey<string>("SpecificationPath"), "specifications"));
            var languagePath = PathToCrossPlatformPath(objectLoader.GetValueOrDefault(new PropertyKey<string>("LanguagePath"), "lang"));

            var specificationSettings = objectLoader.GetValueOrDefault(new PropertyKey<SpecificationSettings>("SpecificationSettings"), DefaultSpecificationSettings(), _specificationSettingsDeserializer);
            IEnumerable<IModAssetInfo> assets = objectLoader.GetValueOrEmpty(new ListKey<ModAssetInfo>("Assets"), _modAssetInfoInfoObjectDeserializer);
            IEnumerable<ModDependency> modDependencies = objectLoader.GetValueOrEmpty(new ListKey<ModDependency>("Dependencies"), _modDependencyObjectDeserializer);
            
            return new Mod(name, version, uniqueId, minimumApiVersion, minimumGameVersion, entryDll, specificationPath, languagePath, specificationSettings, assets, modDependencies);
        }

        private static string PathToCrossPlatformPath(string path)
        {
            return Path.Combine(path.Split("/"));
        }
        
        private static SpecificationSettings DefaultSpecificationSettings()
        {
            return new SpecificationSettings("specifications", new List<ISpecificationDirectory>());
        }
    }
}