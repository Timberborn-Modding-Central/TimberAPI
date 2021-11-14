using Bindito.Core;
using TimberbornAPI.Common;

namespace TimberbornAPI.Dependency {
    public interface IDependencies {
        /**
         * Install a Configurator into a scene to allow dependency injection
         * The class must implement IConfigurator and can use Bind<>() to inject dependencies
         * EntryPoint is optional, defaults to EntryPoint if not specified
         */
        void AddConfigurator(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame);

    }
}
