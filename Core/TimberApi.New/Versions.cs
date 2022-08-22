using TimberApiVersioning;

namespace TimberApi.Core2
{
    public class Versions
    {
        public static Version TimberApiVersion { get; } = new Version(0,7,0,0);

        public static Version MinimumGameVersion { get; } = new Version(0,2,4,0);

        public static Version GameVersion  { get; } = Version.Parse(Timberborn.Versioning.Versions.VersionNumber);
    }
}