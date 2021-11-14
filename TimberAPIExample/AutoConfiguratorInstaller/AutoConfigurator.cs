using System;
using System.Collections.Generic;
using System.Linq;
using Bindito.Core;

namespace TimberAPIExample.AutoConfiguratorInstaller
{
    /// <summary>
    /// NOTE: THIS IS NOT AN EXAMPLE TO USE IN REAL MODS
    /// </summary>
    internal class AutoConfiguratorInGame : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IInGameConfigurator>())
            {
                var instance = (IInGameConfigurator)Activator.CreateInstance(inGameConfigurators);
                containerDefinition.Install(instance);
            }
        }
    }

    /// <summary>
    /// NOTE: THIS IS NOT AN EXAMPLE TO USE IN REAL MODS
    /// </summary>
    internal class AutoConfiguratorMainMenu : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IIMainMenuConfigurator>())
            {
                var instance = (IIMainMenuConfigurator)Activator.CreateInstance(inGameConfigurators);
                containerDefinition.Install(instance);
            }
        }
    }

    /// <summary>
    /// NOTE: THIS IS NOT AN EXAMPLE TO USE IN REAL MODS
    /// </summary>
    internal class AutoConfiguratorEditor : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IEditorConfigurator>())
            {
                var instance = (IEditorConfigurator)Activator.CreateInstance(inGameConfigurators);
                containerDefinition.Install(instance);
            }
        }
    }

    internal static class AutoConfiguratorHelper
    {
        internal static IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
        {
            return System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
        }
    }
}