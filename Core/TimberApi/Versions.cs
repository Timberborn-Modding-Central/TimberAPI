using TimberApi.Common.Extensions;
using TimberApi.VersionSystem;

namespace TimberApi
{
    public class Versions
    {
        public static readonly Version GameVersion = Version.Parse(Timberborn.Versioning.Versions.VersionNumber);

        public static Version TimberApiVersion { get; } = Version.Parse("0.5.0.0".ConvertVersionPlaceholder());

        internal static Version TimberApiMinimumGameVersion { get; } = new(0, 2, 8, 1);
    }
}