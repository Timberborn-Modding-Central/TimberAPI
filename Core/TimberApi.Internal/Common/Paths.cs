using System;

namespace TimberApi.Internal.Common
{
    internal static class Paths
    {
        private static bool _isLoaded;

        public static string LoaderType { get; private set; } = null!;

        public static string Logs { get; private set; } = null!;

        public static string Core { get; private set; } = null!;

        public static string Patchers { get; private set; } = null!;

        public static string Mods { get; private set; } = null!;

        public static void Load()
        {
            if(_isLoaded)
            {
                throw new Exception("TimberApi Environments already loaded");
            }

            _isLoaded = true;

            LoaderType = Environment.GetEnvironmentVariable("TIMBER_LOADER_TYPE") ?? string.Empty;
            Logs = Environment.GetEnvironmentVariable("TIMBER_API_LOG_PATH") ?? string.Empty;
            Core = Environment.GetEnvironmentVariable("TIMBER_API_CORE_PATH") ?? string.Empty;
            Patchers = Environment.GetEnvironmentVariable("TIMBER_API_PATCHERS_PATH") ?? string.Empty;
            Mods = Environment.GetEnvironmentVariable("TIMBER_API_MODS_PATH") ?? string.Empty;
        }
    }
}