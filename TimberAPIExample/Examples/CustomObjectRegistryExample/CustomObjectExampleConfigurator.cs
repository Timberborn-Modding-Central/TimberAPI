using Bindito.Core;

namespace TimberAPIExample.Examples.CustomObjectRegistryExample
{
    public class CustomObjectExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<CustomObjectAddExample>().AsSingleton();
        }
    }
}