using Bindito.Core;

namespace TimberApi.LocalizationSystem
{
    public class LocalizationSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<LocalizationPatcher>().AsSingleton();
        }
    }
}