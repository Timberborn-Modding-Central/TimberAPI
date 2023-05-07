using System;
using TimberApi.SceneSystem;

namespace TimberApi.ConfiguratorSystem
{
    /// <summary>
    ///     Attribute to register configurators
    ///     Attribute should be placed on a `IConfigurator` class, exception will be thrown if not
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfiguratorAttribute : Attribute
    {
        /// <summary>
        ///     Default Timberborn scene configurator entry points
        /// </summary>
        public SceneEntrypoint SceneConfiguratorEntry;

        /// <summary>
        ///     Specify in which scene or scenes you want the configurator to be installed.
        ///     Global can not be combined with any other flag and will lead to a exception
        /// </summary>
        /// <param name="entryPoint">Entry point flag in what scene the configurator should be loaded</param>
        public ConfiguratorAttribute(SceneEntrypoint entryPoint)
        {
            SceneConfiguratorEntry = entryPoint;
        }
    }
}