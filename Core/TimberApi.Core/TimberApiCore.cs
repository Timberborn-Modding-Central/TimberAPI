using System.Diagnostics;
using TimberApi.Core.ConfigSystem;

namespace TimberApi.Core
{
    internal static class TimberApiCore
    {
        public static Stopwatch StartupTimer = null!;

        public static ConfigService Configs = null!;
    }
}