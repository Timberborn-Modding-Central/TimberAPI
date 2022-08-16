using System.Collections.Immutable;
using Bindito.Core;
using HarmonyLib;
using Timberborn.Bootstrapper;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;
using Timberborn.MasterScene;

namespace TimberApi.Internal.ConfiguratorSystem
{
    [HarmonyPatch]
    public static class ConfigurationPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(MasterSceneConfigurator), "Configure")]
        private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorBootstrapper.InGameConfigurators);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuSceneConfigurator), "Configure")]
        private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorBootstrapper.MainMenuConfigurators);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MapEditorSceneConfigurator), "Configure")]
        private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorBootstrapper.MapEditorConfigurators);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BootstrapperConfigurator), "Configure")]
        private static void PatchBootstrapperConfigurator(IContainerDefinition containerDefinition)
        {
            InstallAllConfigurators(containerDefinition, ConfiguratorBootstrapper.BootstrapConfigurators);
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