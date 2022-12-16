using TimberApi.Common.Extensions;
using TimberApi.VersionSystem;

namespace TimberApi
{
    public class Versions
    {
        public static readonly Version GameVersion = Version.Parse(Timberborn.Versioning.Versions.VersionNumber);

        public static Version TimberApiVersion { get; } = Version.Parse("0.5.3.0".ReplacePlaceholderWithFakeVersion());

        internal static Version TimberApiMinimumGameVersion { get; } = new(0, 3, 4, 3);
    }
}