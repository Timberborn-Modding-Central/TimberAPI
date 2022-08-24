using TimberApi.Core.ConfigSystem;
using TimberApi.Core2.Common;

namespace TimberApi.Internal
{
    internal class TimberApiInternal
    {
        public static ConfigService Configs = null!;

        public TimberApiInternal(ConfigServiceFactory configServiceFactory)
        {
            Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiInternal).Assembly, Paths.TimberApi, "TimberAPI");
        }
    }
}