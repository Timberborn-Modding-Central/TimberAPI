using Bindito.Core;
using TimberApi.Common.ConsoleSystem;
using TimberApi.New.Common;
using TimberApi.New.ConfigSystem;

namespace TimberApi.New
{
    internal class TimberApiInternal
    {
        public static readonly string ConsoleTag = "TimberAPI";

        public static IConfigService Configs = null!;

        public static IContainer Container = null!;

        public static IInternalConsoleWriter ConsoleWriter = null!;

        public TimberApiInternal(IConfigServiceFactory configServiceFactory, IInternalConsoleWriter internalConsoleWriter, IContainer container)
        {
            Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiInternal).Assembly, Paths.TimberApi, ConsoleTag);
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