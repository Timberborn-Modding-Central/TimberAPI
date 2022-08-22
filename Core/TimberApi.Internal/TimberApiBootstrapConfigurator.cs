using Bindito.Core;
using TimberApi.Core.BootstrapSystem;

namespace TimberApi.Internal
{
    public class BootstrapConfigurator : ITimberApiEntryConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            // containerDefinition.Bind<Test>().AsSingleton();
        }
    }