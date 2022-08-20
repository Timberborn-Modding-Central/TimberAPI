using TimberApiVersioning;
using Timberborn.Versioning;

namespace TimberApi.Internal
{
    public class TimberApiVersions
    {
        public static Version TimberApiVersion { get; } = new Version(0,7,0,0);

        public static Version MinimumGameVersion { get; } = new Version(0,2,4,0);

        public static Version GameVersion  { get; } = Version.Parse(Versions.VersionNumber);
    }
}