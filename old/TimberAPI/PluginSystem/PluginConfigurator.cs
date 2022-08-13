using Bindito.Core;

namespace TimberbornAPI.PluginSystem
{
    public class PluginConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<PluginLocationService>().AsSingleton();
        }
    }
}