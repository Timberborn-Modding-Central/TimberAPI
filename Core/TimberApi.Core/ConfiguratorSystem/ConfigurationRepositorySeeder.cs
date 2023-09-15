using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Bindito.Core;
using TimberApi.Common.Extensions;
using TimberApi.ConfiguratorSystem;
using TimberApi.ModSystem;
using TimberApi.SceneSystem;

namespace TimberApi.Core.ConfiguratorSystem
{
    internal class ConfigurationRepositorySeeder
    {
        private readonly ConfiguratorRepository _configuratorRepository;

        private readonly IModRepository _modRepository;

        public ConfigurationRepositorySeeder(ConfiguratorRepository configuratorRepository, IModRepository modRepository)
        {
            _configuratorRepository = configuratorRepository;
            _modRepository = modRepository;
        }

        /// <summary>
        ///     Searches for configurators to fill repository
        /// </summary>
        public void Run()
        {
            AddConfiguratorsFromAssemblyToRepository(typeof(TimberApi).Assembly);

            foreach (IMod mod in _modRepository.GetCodeMods())
            {
                AddConfiguratorsFromAssemblyToRepository(mod.LoadedAssembly!);
            }
        }

        public void AddConfiguratorsFromAssemblyToRepository(Assembly assembly)
        {
            IEnumerable<Type> configuratorTypes = assembly.GetTypesByAttribute<ConfiguratorAttribute>();
            ImmutableArray<IConfigurator> configurators = ValidateAndCreateConfigurators(configuratorTypes).ToImmutableArray();

            var filteredConfigurators = FilterConfiguratorsWithoutMissingModDependencies(configurators).ToImmutableArray();

            _configuratorRepository.AddRange(SceneEntrypoint.MainMenu, GetConfiguratorWithSceneFlag(filteredConfigurators, SceneEntrypoint.MainMenu));
            _configuratorRepository.AddRange(SceneEntrypoint.InGame, GetConfiguratorWithSceneFlag(filteredConfigurators, SceneEntrypoint.InGame));
            _configuratorRepository.AddRange(SceneEntrypoint.MapEditor, GetConfiguratorWithSceneFlag(filteredConfigurators, SceneEntrypoint.MapEditor));
        }
        
        /// <summary>
        ///     Configurator filter based on defined mod dependencies
        /// </summary>
        /// <param name="configurators">validated configurators</param>
        /// <returns>Filtered configurators without missing mod dependencies</returns>
        private IEnumerable<IConfigurator> FilterConfiguratorsWithoutMissingModDependencies(IEnumerable<IConfigurator> configurators)
        {
            foreach (var configurator in configurators)
            {
                var attribute = configurator.GetType().GetCustomAttribute<RequiredModDependencies>();
                if(attribute == null || attribute.ModDependencies.All(modDependency => _modRepository.TryGetByUniqueId(modDependency, out _))) 
                    yield return configurator;
            }
        }

        /// <summary>
        ///     Configurator filter based on flag
        ///     Removes duplicated code
        /// </summary>
        /// <param name="configurators">validated configurators</param>
        /// <param name="sceneFlag">Filter based if attribute has set flag</param>
        /// <returns>Filtered configurators for specific flag</returns>
        private static IEnumerable<IConfigurator> GetConfiguratorWithSceneFlag(IEnumerable<IConfigurator> configurators, SceneEntrypoint sceneFlag)
        {
            return configurators.Where(configurator => configurator.GetType().GetCustomAttribute<ConfiguratorAttribute>().SceneConfiguratorEntry.HasFlag(sceneFlag));
        }

        /// <summary>
        ///     Creates and validates list of configurators
        /// </summary>
        /// <param name="configuratorTypes">Classes with ConfiguratorAttribute</param>
        /// <returns>Validated IConfigurator instances</returns>
        private static IEnumerable<IConfigurator> ValidateAndCreateConfigurators(IEnumerable<Type> configuratorTypes)
        {
            return configuratorTypes.Select(type =>
            {
                ValidateConfiguratorAttributeType(type);
                return (IConfigurator) Activator.CreateInstance(type);
            });
        }

        /// <summary>
        ///     Validates if the class is a valid class for a `IConfigurator`
        ///     Without validation unexpected errors may occur making it hard to debug
        /// </summary>
        /// <param name="configuratorType"></param>
        /// <exception cref="ConfigurationValidationException">Configurator class type</exception>
        private static void ValidateConfiguratorAttributeType(Type configuratorType)
        {
            if (configuratorType.GetInterface(nameof(IConfigurator)) == null)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} does not extend `IConfiguration`");
            }

            if (configuratorType.IsAbstract)
            {
                throw new ConfigurationValidationException($"{configuratorType.FullName} may not be a abstract class");
            }
        }
    }
}