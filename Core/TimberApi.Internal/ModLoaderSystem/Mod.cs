using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using TimberApi.Core.ModSystem;
using TimberApiVersioning;

namespace TimberApi.Internal.ModLoaderSystem
{
    internal class Mod : IMod
    {
        public Mod(string name, Version version, string uniqueId, Version minimumApiVersion, Version minimumGameVersion, string entryDll, string specificationPath, string languagePath, IEnumerable<IModAsset> assets, IEnumerable<IModDependency> dependencies)
        {
            Name = name;
            Version = version;
            UniqueId = uniqueId;
            MinimumApiVersion = minimumApiVersion;
            MinimumGameVersion = minimumGameVersion;
            EntryDll = entryDll;
            SpecificationPath = specificationPath;
            LanguagePath = languagePath;
            Assets = assets.ToImmutableArray();
            Dependencies = dependencies.ToImmutableArray();
        }

        public string Name { get; set; }

        public Version Version { get; set; }

        public string UniqueId { get; set; }

        public Version MinimumApiVersion { get; set; }

        public Version MinimumGameVersion { get; set; }

        public string EntryDll { get; set; }

        public string SpecificationPath { get; set; }

        public string LanguagePath { get; set; }

        public ImmutableArray<IModAsset> Assets { get; set; }

        public ImmutableArray<IModDependency> Dependencies { get; set; }

        public IEnumerable<IModDependency> LoadedDependencies => Dependencies.Where(dependency => dependency.IsLoaded);

        public bool IsCodelessMod => string.IsNullOrWhiteSpace(EntryDll);

        public bool IsLoaded { get; set; } = false;

        public bool LoadFailed { get; set; } = false;

        public Assembly? LoadedAssembly { get; set; }

        public string DirectoryPath { get; set; } = null!;

        public string DirectoryName { get; set; } = null!;
    }
}