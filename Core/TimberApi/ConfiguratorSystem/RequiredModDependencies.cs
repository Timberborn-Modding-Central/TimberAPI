using System;

namespace TimberApi.ConfiguratorSystem
{
    /// <summary>
    ///     Attribute to register mod dependencies for a configurator
    ///     Attribute should be placed on a `IConfigurator` class with a Configurator attribute, optional
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RequiredModDependencies : Attribute
    {
        /// <summary>
        ///     Required ModIds to install the configurator
        /// </summary>
        public string[] ModDependencies;

        /// <summary>
        ///     Specify which mods are required to install the configurator.
        ///     Requires ALL mods to be active.
        /// </summary>
        /// <param name="modDependencies">Optional unique mod id's that are required to be active to install the configurator</param>
        public RequiredModDependencies(params string[] modDependencies)
        {
            ModDependencies = modDependencies;
        }
    }
}