using Bindito.Core;
using HarmonyLib;
using Timberborn.Bootstrapper;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.ConsoleSystem
{
    [HarmonyPatch(typeof(BootstrapperConfigurator), "Configure", typeof(IContainerDefinition))]
    public static class BootstrapperPatch
    {
        public static void Prefix(BootstrapperConfigurator __instance)
        {
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<UIDocument>();
            gameObject.AddComponent<ConsoleMonitor>();
            Object.DontDestroyOnLoad(gameObject);
        }
    }
}