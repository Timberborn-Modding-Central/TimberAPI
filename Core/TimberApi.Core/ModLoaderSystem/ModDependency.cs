using TimberApi.Common.VersionSystem;
using TimberApi.New.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModDependency : IModDependency
    {
        public ModDependency(string uniqueId, Version minimumVersion, bool optional)
        {
            UniqueId = uniqueId;
            MinimumVersion = minimumVersion;
            Optional = optional;
        }

        public bool IsLoaded => Mod is { IsLoaded: true };

        public IMod? Mod { get; set; }

        public string UniqueId { get; set; }

        public Version MinimumVersion { get; set; }

        public bool Optional { get; set; }
    }
}