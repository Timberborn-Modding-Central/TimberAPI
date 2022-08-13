using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Bindito.Core;
using TimberApi.Core.ConfiguratorSystem;
using TimberApi.Internal.Common;

namespace TimberApi.Internal.ConfiguratorSystem
{
    internal static class ConfiguratorBootstrapper
    {
        private static bool _isInitialized;

        public static ImmutableArray<IConfigurator> BootstrapConfigurators { get; private set; }

        public static ImmutableArray<IConfigurator> MainMenuConfigurators { get; private set; }

        public static ImmutableArray<IConfigurator> InGameConfigurators { get; private set; }

        public static ImmutableArray<IConfigurator> MapEditorConfigurators { get; private set; }

        /// <summary>
        /// Searches and loads scene configurators
        /// </summary>
        public static void Initialize()
        {
            if(_isInitialized)
            {
                throw new Exception("ConfiguratorBootstrapper already initialized");
            }

            _isInitialized = true;

            ImmutableArray<IConfigurator> validatedConfigurators = ValidateAndCreateConfigurators(ReflectionHelper.GetTypesInAssemblyByAttribute<ConfiguratorAttribute>()).ToImmutableArray();

            BootstrapConfigurators = GetConfiguratorWithSceneFlag(validatedConfigurators, SceneConfiguratorEntry.Global).ToImmutableArray();
            MainMenuConfigurators = GetConfiguratorWithSceneFlag(validatedConfigurators, SceneConfiguratorEntry.MainMenu).ToImmutableArray();
            InGameConfigurators = GetConfiguratorWithSceneFlag(validatedConfigurators, SceneConfiguratorEntry.InGame).ToImmutableArray();
            MapEditorConfigurators = GetConfiguratorWithSceneFlag(validatedConfigurators, SceneConfiguratorEntry.MapEditor).ToImmutableArray();
        }

        /// <summary>
        /// Configurator filter based on flag
        /// Removes duplicated code
        /// </summary>
        /// <param name="configurators">validated configurators</param>
        /// <param name="sceneFlag">Filter based if attribute has set flag</param>
        /// <returns>Filtered configurators for specific flag</returns>
        private static IEnumerable<IConfigurator> GetConfiguratorWithSceneFlag(IEnumerable<IConfigurator> configurators, SceneConfiguratorEntry sceneFlag)
        {
            return configurators.Where(configurator => configurator.GetType().GetCustomAttribute<ConfiguratorAttribute>().SceneConfiguratorEntry.HasFlag(sceneFlag));
        }

        /// <summary>
        /// Creates and validates list of configurators
        /// </summary>
        /// <param name="configuratorTypes">Classes with ConfiguratorAttribute</param>
        /// <returns>Validated IConfigurator instances</returns>
        private static IEnumerable<IConfigurator> ValidateAndCreateConfigurators(IEnumerable<Type> configuratorTypes)
        {
            return configuratorTypes.Select(type =>
            {
                ValidateConfiguratorAttributeType(type);
                return type.CreateInstance<IConfigurator>();
            });
        }

        /// <summary>
        /// Validates if the class is a valid class for a `IConfigurator`
        /// Without validation unexpected errors may occur making it hard to debug
        /// </summary>
        /// <param name="configuratorType"></param>
        /// <exception cref="ConfigurationValidationException">Configurator class type</exception>
        private static void ValidateConfiguratorAttributeType(Type configuratorType)
        {

            if(configuratorType.GetInterface(nameof(IConfigurator)) == null)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} does not extend `IConfiguration`");
            }

            if(configuratorType.IsAbstract)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} may not be a abstract class");
            }

            var configuratorAttribute = configuratorType.GetCustomAttribute<ConfiguratorAttribute>();
            if(configuratorAttribute.SceneConfiguratorEntry.HasFlag(SceneConfiguratorEntry.Global) && configuratorAttribute.SceneConfiguratorEntry > (SceneConfiguratorEntry) 1)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} tried to combine SceneConfiguratorEntry.Global with any other flags");
            }
        }
    }
}
