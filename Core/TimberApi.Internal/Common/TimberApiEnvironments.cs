using System;

namespace TimberApi.Internal.Common
{
    internal static class TimberApiEnvironments
    {
        private static bool _isLoaded;

        public static string LoaderType { get; private set; } = null!;

        public static string LogPath { get; private set; } = null!;

        public static string CorePath { get; private set; } = null!;

        public static string PatcherPath { get; private set; } = null!;

        public static string ModsPath { get; private set; } = null!;

        public static void Load()
        {
            if(_isLoaded)
            {
                throw new Exception("TimberApi Environments already loaded");
            }

            _isLoaded = true;

            LoaderType = Environment.GetEnvironmentVariable("TIMBER_LOADER_TYPE") ?? string.Empty;
            LogPath = Environment.GetEnvironmentVariable("TIMBER_API_LOG_PATH") ?? string.Empty;
            CorePath = Environment.GetEnvironmentVariable("TIMBER_API_CORE_PATH") ?? string.Empty;
            PatcherPath = Environment.GetEnvironmentVariable("TIMBER_API_PATCHERS_PATH") ?? string.Empty;
            ModsPath = Environment.GetEnvironmentVariable("TIMBER_API_MODS_PATH") ?? string.Empty;
        }
    }
}