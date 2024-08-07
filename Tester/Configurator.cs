using Bindito.Core;

namespace Tester;

[Context("Game")]
public class Configurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        containerDefinition.Bind<Test>().AsSingleton();
    }
}