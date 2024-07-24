using Bindito.Core;
using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.GameScene;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;

namespace TimberApi;

public class SceneManager
{
    public delegate void SceneChangedCallback(Scene previousScene, Scene currentScene,
        IContainerDefinition currentContainerDefinition);

    public static Scene PreviousScene { get; private set; }

    public static Scene CurrentScene { get; private set; } = Scene.Unknown;

    public static event SceneChangedCallback SceneChanged = delegate { };

    internal static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<GameSceneInstaller>(nameof(GameSceneInstaller.Configure)),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMasterSceneConfigurator))
        );

        harmony.Patch(
            harmony.GetMethodInfo<MainMenuSceneConfigurator>(nameof(GameSceneInstaller.Configure)),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMainMenuSceneConfigurator))
        );

        harmony.Patch(
            harmony.GetMethodInfo<MapEditorSceneConfigurator>(nameof(GameSceneInstaller.Configure)),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMapEditorSceneConfigurator))
        );
    }

    private static void PatchMasterSceneConfigurator(IContainerDefinition containerDefinition)
    {
        ChangeScene(Scene.Game, containerDefinition);
    }

    private static void PatchMainMenuSceneConfigurator(IContainerDefinition containerDefinition)
    {
        ChangeScene(Scene.MainMenu, containerDefinition);
    }

    private static void PatchMapEditorSceneConfigurator(IContainerDefinition containerDefinition)
    {
        ChangeScene(Scene.MapEditor, containerDefinition);
    }

    public static void ChangeScene(Scene sceneEntrypoint, IContainerDefinition currentContainerDefinition)
    {
        PreviousScene = CurrentScene;
        CurrentScene = sceneEntrypoint;
        SceneChanged(PreviousScene, CurrentScene, currentContainerDefinition);
    }
}