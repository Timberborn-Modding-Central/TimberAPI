using Bindito.Core;

namespace TimberApi.LocalizationSystem
{
    public class LocalizationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<LocalizationPatcher>().AsSingleton();
        }
    }
}