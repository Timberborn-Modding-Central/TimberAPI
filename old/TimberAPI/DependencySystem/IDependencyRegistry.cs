using System.Collections.Generic;
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

        /// <summary>
        /// Install multiple Configurators into a scene to allow dependency injection
        /// The classes must implement IConfigurator and can use Bind<>() to inject dependencies
        /// </summary>
        /// <param name="configurators">The configurators to inject, which do the binding</param>
        /// <param name="entryPoint">Scene to bind to, defaults to InGame</param>
        void AddConfigurators(List<IConfigurator> configurators, SceneEntryPoint entryPoint = SceneEntryPoint.InGame);

        /// <summary>
        /// Install a Configurator into the InGame scene before anything else to allow dependency injection
        /// Use only if you need to - e.g. before objects are loaded
        /// The class must implement IConfigurator and can use Bind<>() to inject dependencies
        /// </summary>
        /// <param name="configurator">The configurator class to inject, which does the binding</param>
        /// <param name="entryPoint">Scene to bind to, defaults to InGame</param>
        void AddConfiguratorBeforeLoad(IConfigurator configurator, SceneEntryPoint entryPoint = SceneEntryPoint.InGame);
    }
}
