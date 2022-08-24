using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using TimberApi.Core2.ConfigSystem;
using TimberApiVersioning;

namespace TimberApi.Core2.ModSystem
{
    public interface IMod
    {
        string Name { get; }

        Version Version { get; }

        string UniqueId { get; }

        Version MinimumApiVersion { get; }

        Version MinimumGameVersion { get; }

        string EntryDll { get; }

        string SpecificationPath { get; }

        string LanguagePath { get; set; }

        ImmutableArray<IModAsset> Assets { get; }

        ImmutableArray<IModDependency> Dependencies { get; }

        IEnumerable<IModDependency> LoadedDependencies { get; }

        bool IsCodelessMod { get; }

        bool IsLoaded { get; }

        bool LoadFailed { get; set; }

        Assembly? LoadedAssembly { get; }

        string DirectoryPath { get; }

        string DirectoryName { get; }

        IConfigService Configs { get; }
    }
}