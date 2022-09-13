using TimberApi.VersionSystem;

namespace TimberApi.ModSystem
{
    public interface IModDependency
    {
        bool IsLoaded { get; }

        IMod? Mod { get; set; }

        string UniqueId { get; }

        Version MinimumVersion { get; }

        bool Optional { get; }
    }
}