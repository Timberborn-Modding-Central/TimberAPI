﻿using TimberApi.Common.Extensions;
using TimberApi.New.VersionSystem;

namespace TimberApi.New
{
    public class Versions
    {
        public static readonly Version GameVersion = Version.Parse(Timberborn.Versioning.Versions.VersionNumber);

        public static Version TimberApiVersion { get; } = Version.Parse("TIMBERAPI_VERSION_PLACEHOLDER".ConvertVersionPlaceholder());

        internal static Version TimberApiMinimumGameVersion { get; } = new(0, 2, 7);
    }
}