using Bindito.Core;

namespace TimberApi.SpecificationSystem
{
    internal class SpecificationSystemGlobalConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ObjectSpecificationCacheService>().AsSingleton();
        }
    }
}