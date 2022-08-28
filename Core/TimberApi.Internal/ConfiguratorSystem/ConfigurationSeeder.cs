﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Bindito.Core;
using TimberApi.Core.Common;
using TimberApi.Core.SingletonSystem.Singletons;
using TimberApi.Core2.Common;
using TimberApi.Core2.ConfiguratorSystem;

namespace TimberApi.Internal.ConfiguratorSystem
{
    internal class ConfigurationSeeder : ITimberApiSeeder
    {
        private readonly ConfiguratorRepository _configuratorRepository;

        public ConfigurationSeeder(ConfiguratorRepository configuratorRepository)
        {
            _configuratorRepository = configuratorRepository;
        }

        /// <summary>
        /// Searches for configurators to fill repository
        /// </summary>
        public void Run()
        {
            ImmutableArray<IConfigurator> validatedConfigurators = ValidateAndCreateConfigurators(ReflectionHelper.GetTypesInAssemblyByAttribute<ConfiguratorAttribute>()).ToImmutableArray();

            _configuratorRepository.SetMainMenuConfigurators(GetConfiguratorWithSceneFlag(validatedConfigurators, SceneEntrypoint.MainMenu));
            _configuratorRepository.SetInGameConfigurators(GetConfiguratorWithSceneFlag(validatedConfigurators, SceneEntrypoint.InGame));
            _configuratorRepository.SetMapEditorConfigurators(GetConfiguratorWithSceneFlag(validatedConfigurators, SceneEntrypoint.MapEditor));
        }

        /// <summary>
        /// Configurator filter based on flag
        /// Removes duplicated code
        /// </summary>
        /// <param name="configurators">validated configurators</param>
        /// <param name="sceneFlag">Filter based if attribute has set flag</param>
        /// <returns>Filtered configurators for specific flag</returns>
        private IEnumerable<IConfigurator> GetConfiguratorWithSceneFlag(IEnumerable<IConfigurator> configurators, SceneEntrypoint sceneFlag)
        {
            return configurators.Where(configurator => configurator.GetType().GetCustomAttribute<ConfiguratorAttribute>().SceneConfiguratorEntry.HasFlag(sceneFlag));
        }

        /// <summary>
        /// Creates and validates list of configurators
        /// </summary>
        /// <param name="configuratorTypes">Classes with ConfiguratorAttribute</param>
        /// <returns>Validated IConfigurator instances</returns>
        private IEnumerable<IConfigurator> ValidateAndCreateConfigurators(IEnumerable<Type> configuratorTypes)
        {
            return configuratorTypes.Select(type =>
            {
                ValidateConfiguratorAttributeType(type);
                return (IConfigurator)Activator.CreateInstance(type);
            });
        }

        /// <summary>
        /// Validates if the class is a valid class for a `IConfigurator`
        /// Without validation unexpected errors may occur making it hard to debug
        /// </summary>
        /// <param name="configuratorType"></param>
        /// <exception cref="ConfigurationValidationException">Configurator class type</exception>
        private void ValidateConfiguratorAttributeType(Type configuratorType)
        {
            if(configuratorType.GetInterface(nameof(IConfigurator)) == null)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} does not extend `IConfiguration`");
            }

            if(configuratorType.IsAbstract)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} may not be a abstract class");
            }
        }

    }
}