using Bindito.Core;
using TimberApi.Common;
using TimberApi.Common.ConsoleSystem;
using TimberApi.ConfigSystem;
using TimberApi.DependencyContainerSystem;
using UnityEngine;

namespace TimberApi
{
    internal class TimberApi
    {
        public static readonly string ConsoleTag = "TimberAPI";

        public static IConfigService Configs = null!;

        public static IInternalConsoleWriter ConsoleWriter = null!;

        public TimberApi(IConfigServiceFactory configServiceFactory, IInternalConsoleWriter internalConsoleWriter, IContainer container)
        {
            Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApi).Assembly, Paths.TimberApi, ConsoleTag);
            ConsoleWriter = internalConsoleWriter;
            DependencyContainer.Container = container;
        }

        public static class AssetInfo
        {
            public static string Prefix = "TimberAPI";

            public static string Folder = "assets";
        }
    }
}