using Bindito.Core;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core2.Common;

namespace TimberApi.Internal
{
    internal class TimberApiInternal
    {
        public static ConfigService Configs = null!;

        public static IContainer Container = null!;

        public static IInternalConsoleWriter ConsoleWriter = null!;

        public TimberApiInternal(ConfigServiceFactory configServiceFactory, IInternalConsoleWriter internalConsoleWriter, IContainer container)
        {
            Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiInternal).Assembly, Paths.TimberApi, "TimberAPI");
            ConsoleWriter = internalConsoleWriter;
            Container = container;
        }

        public static class AssetInfo
        {
            public static string Prefix = "TimberAPI";

            public static string Folder = "assets";

        }
    }
}