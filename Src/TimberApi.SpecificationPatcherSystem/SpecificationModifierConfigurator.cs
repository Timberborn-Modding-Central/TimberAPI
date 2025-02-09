using Bindito.Core;
using TimberApi.SpecificationPatcherSystem.SpecificationModifierResolvers;

namespace TimberApi.SpecificationPatcherSystem;

[Context("MainMenu")]
[Context("MapEditor")]
[Context("Game")]
public class SpecificationModifierConfigurator : Configurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<SpecificationModifierApplier>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationModifierResolver>().To<ModSpecificationModifierResolver>().AsSingleton();
    }
}