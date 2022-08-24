using System.Collections.Immutable;
using Bindito.Core;
using HarmonyLib;
using TimberApi.Core.SingletonSystem.Singletons;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.Internal.ConfiguratorSystem
{
    public class ConfiguratorPatcher : ITimberApiLoadableSingleton
    {
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
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.InGameConfigurators);
        }

        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.MainMenuConfigurators);
        }

        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorRepository.MapEditorConfigurators);
        }

        private static void InstallAllConfigurators(IContainerDefinition containerDefinition, ImmutableArray<IConfigurator> configurators)
        {
            foreach (IConfigurator configurator in configurators)
            {
                containerDefinition.Install(configurator);
            }
        }
    }
}