using System;
using System.Collections.Generic;
using System.Linq;
using Bindito.Core;

namespace TimberbornAPI.DependencySystem
{

    internal class AutoConfiguratorInGame : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IAutoConfiguratorInGame>())
            {
                var instance = (IAutoConfiguratorInGame)Activator.CreateInstance(inGameConfigurators);
                containerDefinition.Install(instance);
            }
        }
    }

    internal class AutoConfiguratorMainMenu : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IAutoConfiguratorMainMenu>())
            {
                var instance = (IAutoConfiguratorInGame)Activator.CreateInstance(inGameConfigurators);
                containerDefinition.Install(instance);
            }
        }
    }

    internal class AutoConfiguratorMapEditor : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            foreach (Type inGameConfigurators in AutoConfiguratorHelper.GetAllTypesThatImplementInterface<IAutoConfiguratorMapEditor>())
            {
                var instance = (IAutoConfiguratorMapEditor)Activator.CreateInstance(inGameConfigurators);
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