using Bindito.Core.Internal;
using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.SoakedEffects;
using UnityEngine;

namespace TimberApi;

public class ContextManager
{
    public delegate void SceneChangedCallback(string previousScene, string currentScene);

    public static string PreviousContext { get; private set; }

    public static string CurrentContext { get; private set; } = "Unknown";

    public static event SceneChangedCallback ContextChanged = delegate { };

    internal static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<ContainerDefinition>(nameof(ContainerDefinition.InstallAll), [typeof(string)]),
            harmony.GetHarmonyMethod<ContextManager>(nameof(Test))
        );
    }
    
    private static void Test(string contextName)
    {
        Debug.LogError($"Changing context: {contextName}");
        ChangeScene(contextName);
    }

    public static void ChangeScene(string sceneEntrypoint)
    {
        PreviousContext = CurrentContext;
        CurrentContext = sceneEntrypoint;
        ContextChanged(PreviousContext, CurrentContext);
    }
}