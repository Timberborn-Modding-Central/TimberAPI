using Bindito.Core;
using TimberbornAPI.Common;

namespace TimberbornAPI.DependencySystem
{
    public interface IDependencyRegistry
    {
        /// <summary>
        /// Install a Configurator into a scene to allow dependency injection
        /// The class must implement IConfigurator and can use Bind<>() to inject dependencies
        /// </summary>
        /// <param name="configurator">The configurator class to inject, which does the binding</param>
        /// <param name="entryPoint">Scene to bind to, defaults to InGame</param>
        void AddConfigurator(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame);
    }
}
