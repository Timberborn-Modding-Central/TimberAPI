using System.IO;
using System.Reflection;
using HarmonyLib;
using TimberApi.Internal.Common;
using TimberApi.Internal.ConfiguratorSystem;
using TimberApi.Internal.LoggerSystem;
using TimberApi.LoaderInterfaces;
using Timberborn.Core;
using UnityEngine;

namespace TimberApi.Internal
{
    public class Test : MonoBehaviour
    {
        private void Awake()
        {
            File.WriteAllText("AAAA_LAST.txt", "AA");
        }
    }

    internal class TimberApiEntrypoint : ITimberApiPatcher
    {
        public void Initialize()
        {
            TimberApiEnvironments.Load();
            ConfiguratorBootstrapper.Initialize();
            Harmony harmony = new Harmony("timberApi.patcher");
            harmony.PatchAll();

            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
            ConsoleLogger.Instance.Log("Tobbert is kewl");
        }
    }

    [HarmonyPatch]
    static class FixLag
    {
        private static MethodInfo TargetMethod() {

            return AccessTools.Method(typeof(GameStartLogger), "AppendDriveInfo");
        }

        private static bool Prefix()
        {
            return false;
        }
    }
}