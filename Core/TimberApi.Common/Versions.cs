using TimberApi.Common.VersionSystem;

namespace TimberApi.Common
{
    public class Versions
    {
        public static Version TimberApiVersion { get; } = new Version(0,7,0,0);

        public static Version TimberApiMinimumGameVersion { get; } = new Version(0,2,4,0);

        public static readonly Version GameVersion   = Version.Parse(Timberborn.Versioning.Versions.VersionNumber);
    }
}