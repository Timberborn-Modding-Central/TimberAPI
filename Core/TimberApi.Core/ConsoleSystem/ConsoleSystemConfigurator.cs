using Bindito.Core;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IInternalConsoleWriter>().To<InternalConsoleWriter>().AsSingleton();
        }
    }
}