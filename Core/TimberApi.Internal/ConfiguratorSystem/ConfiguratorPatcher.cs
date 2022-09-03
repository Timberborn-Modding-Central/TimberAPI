using System.Collections.Immutable;
using System.Diagnostics;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Core2.Common;
using TimberApi.Internal.SingletonSystem;
using TimberApi.Internal.SingletonSystem.Singletons;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;
using UnityEngine.Rendering;

namespace TimberApi.Internal.ConfiguratorSystem
{
    public class ConfiguratorPatcher : ITimberApiLoadableSingleton
    {
        public static SceneEntrypoint CurrentScene;

        public static SceneEntrypoint PreviousScene;

        public void Load()
        {
            Harmony harmony = new Harmony("TimberApi.configurators");

            harmony.Patch(
                original: AccessTools.Method(typeof(MasterSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMasterSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MainMenuSceneConfigurator), "Configure"),
                prefix:  new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMainMenuSceneConfigurator)))
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(MapEditorSceneConfigurator), "Configure"),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(ConfiguratorPatcher), nameof(PatchMapEditorSceneConfigurator)))
            );
        }

        private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
        {
            PreviousScene = CurrentScene;
            CurrentScene = SceneEntrypoint.InGame;
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.InGameConfigurators);
        }

        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            PreviousScene = CurrentScene;
            CurrentScene = SceneEntrypoint.MainMenu;
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.MainMenuConfigurators);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            PreviousScene = CurrentScene;
            CurrentScene = SceneEntrypoint.MapEditor;
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.MapEditorConfigurators);
        }

        private static void InstallAllConfigurators(IContainerDefinition containerDefinition, ImmutableArray<IConfigurator> configurators)
        {
            containerDefinition.Bind<ISingletonRepository>().To<SingletonRepository>().AsSingleton();
            var instance = new SingletonListener();
            containerDefinition.Bind<SingletonListener>().ToInstance(instance);
            containerDefinition.AddInjectionListener(instance);
            containerDefinition.AddProvisionListener(instance);

            foreach (IConfigurator configurator in configurators)
            {
                containerDefinition.Install(configurator);
            }

            containerDefinition.Bind<SingletonRunner>().AsSingleton();
        }
    }
}