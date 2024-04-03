using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace DebugMod
{
    [Configurator(SceneEntrypoint.All)]
    public class Configurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // containerDefinition.Bind<TestButtonBuilder>().AsTransient();
        }
    }
    
    [Configurator(SceneEntrypoint.InGame)]
    public class InGameConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            
        }
    }
    
    [Configurator(SceneEntrypoint.MainMenu)]
    public class MainMenuConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            
        }
    }
}