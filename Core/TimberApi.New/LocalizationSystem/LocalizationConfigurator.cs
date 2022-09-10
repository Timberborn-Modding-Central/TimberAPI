using Bindito.Core;

namespace TimberApi.New.LocalizationSystem
{
    public class LocalizationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<LocalizationPatcher>().AsSingleton();
        }
    }
}