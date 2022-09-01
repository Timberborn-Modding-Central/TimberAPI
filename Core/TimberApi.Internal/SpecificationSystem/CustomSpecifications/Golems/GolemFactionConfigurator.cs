using Bindito.Core;
using TimberApi.Core2.Common;
using TimberApi.Core2.ConfiguratorSystem;

namespace TimberApi.Internal.SpecificationSystem.CustomSpecifications.Golems
{
    [Configurator(SceneEntrypoint.InGame)]
    public class GolemFactionConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ISpecificationGenerator>().To<GolemSpecificationGenerator>().AsSingleton();
            containerDefinition.Bind<GolemFactionService>().AsSingleton();
            containerDefinition.Bind<GolemFactionSpecificationObjectDeserializer>().AsSingleton();
        }
    }

    public class GolemFactionPatchConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<GolemFactionPatcher>().AsSingleton();
        }
    }
}