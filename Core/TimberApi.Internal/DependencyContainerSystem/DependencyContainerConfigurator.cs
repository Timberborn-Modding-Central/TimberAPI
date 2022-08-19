using Bindito.Core;

namespace TimberApi.Internal.DependencyContainerSystem
{
    public class DependencyContainerConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<DependencyContainer>().AsSingleton();
        }
    }
}