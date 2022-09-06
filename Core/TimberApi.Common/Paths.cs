using System;

namespace TimberApi.Common
{
    public static class Paths
    {
        public static string LoaderType { get; } = Environment.GetEnvironmentVariable("TIMBER_LOADER_TYPE") ?? string.Empty;

        public static string TimberApi { get; } = Environment.GetEnvironmentVariable("TIMBER_API_PATH") ?? string.Empty;

        public static string Logs { get; } = Environment.GetEnvironmentVariable("TIMBER_API_LOG_PATH") ?? string.Empty;

        public static string Core { get; } = Environment.GetEnvironmentVariable("TIMBER_API_CORE_PATH") ?? string.Empty;

        public static string Patchers { get; } = Environment.GetEnvironmentVariable("TIMBER_API_PATCHERS_PATH") ?? string.Empty;

        public static string Mods { get; } = Environment.GetEnvironmentVariable("TIMBER_API_MODS_PATH") ?? string.Empty;

        public static string Configs { get; } = Environment.GetEnvironmentVariable("TIMBER_API_CONFIGS_PATH") ?? string.Empty;

        public static string BepInExPlugins { get; } = Environment.GetEnvironmentVariable("BEP_IN_EX_PLUGIN_PATH") ?? string.Empty;
    }
}