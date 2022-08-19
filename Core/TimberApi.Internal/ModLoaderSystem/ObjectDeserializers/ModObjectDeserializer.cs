using System.Collections.Generic;
using TimberApi.Core.ModSystem;
using TimberApi.Internal.Common;
using TimberApiVersioning;
using Timberborn.Persistence;

namespace TimberApi.Internal.ModLoaderSystem.ObjectDeserializers
{
    public class ModObjectDeserializer : IObjectSerializer<Mod>
    {
        private readonly ModDependencyObjectDeserializer _modDependencyObjectDeserializer;

        private readonly ModLanguagePathObjectDeserializer _modLanguagePathObjectDeserializer;

        public ModObjectDeserializer(ModDependencyObjectDeserializer modDependencyObjectDeserializer, ModLanguagePathObjectDeserializer modLanguagePathObjectDeserializer)
        {
            _modDependencyObjectDeserializer = modDependencyObjectDeserializer;
            _modLanguagePathObjectDeserializer = modLanguagePathObjectDeserializer;
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
            string specificationPath = objectLoader.GetValueOrDefault(new PropertyKey<string>("SpecificationPath"), "specifications");
            string languagePath = objectLoader.GetValueOrDefault(new PropertyKey<string>("LanguagePath"), "lang");
            IEnumerable<IModAsset> assets = objectLoader.GetValueOrEmpty(new ListKey<ModAsset>("Assets"), _modLanguagePathObjectDeserializer);
            IEnumerable<ModDependency> modDependencies = objectLoader.GetValueOrEmpty(new ListKey<ModDependency>("Dependencies"), _modDependencyObjectDeserializer);
            return new Mod(name, version, uniqueId, minimumApiVersion, minimumGameVersion, entryDll, specificationPath, languagePath, assets, modDependencies);
        }
    }
}