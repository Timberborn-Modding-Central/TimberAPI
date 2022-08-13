using Bindito.Core;

namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Golems
{
    public class GolemFactionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<GolemFactionService>().AsSingleton();
            containerDefinition.Bind<GolemFactionSpecificationObjectDeserializer>().AsSingleton();
        }
    }
}