using Bindito.Core;

namespace TimberApi.Core.LoggingSystem
{
    public class LoggingSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<Logger>().AsSingleton();
        }
    }
}