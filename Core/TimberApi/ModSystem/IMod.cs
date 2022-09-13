using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using TimberApi.ConfigSystem;
using TimberApi.VersionSystem;

namespace TimberApi.ModSystem
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

        ImmutableArray<IModAssetInfo> Assets { get; }

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