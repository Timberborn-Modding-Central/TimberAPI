using Bindito.Core;

namespace TimberbornAPI {
    public interface IDependencies {
        /**
         * Install a Configurator into a scene to allow dependency injection
         * The class must implement IConfigurator and can use Bind<>() to inject dependencies
         * EntryPoint is optional, defaults to EntryPoint if not specified
         */
        void AddConfigurator(IConfigurator configurator, EntryPoint entryPoint = EntryPoint.InGame);

        /**
         * Place to inject the dependencies into
         */
        public enum EntryPoint {
            InGame,
            MainMenu,
            MapEditor
        }
    }
}
