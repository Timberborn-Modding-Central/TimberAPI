using Bindito.Core;
using HarmonyLib;
using Timberborn.Bootstrapper;
using UnityEngine;

namespace TimberApi.Internal.LoggerSystem
{
    public static class UnityConsoleListener
    {
        public static void Initialize()
        {
            Application.logMessageReceived += HandleUnityLog;
        }

        private static void HandleUnityLog(string condition, string stacktrace, LogType type)
        {
            ConsoleLogger.Instance.Log(condition);
        }

        [HarmonyPatch(typeof(BootstrapperConfigurator), "Configure", typeof(IContainerDefinition))]
        public static class BootstrapperPatch
        {
            public static void Prefix()
            {
                Initialize();
            }
        }
    }


}