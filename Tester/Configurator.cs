using Bindito.Core;
using TimberApi.SpecificationSystem;

namespace Tester;

[Context("Game")]
public class Configurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<Test>().AsSingleton();
        containerDefinition.MultiBind<ISpecificationGenerator>().To<Generator>().AsSingleton();
    }
}