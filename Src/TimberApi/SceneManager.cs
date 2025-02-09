using HarmonyLib;
using TimberApi.HarmonySystem;
using Timberborn.GameScene;
using Timberborn.MainMenuScene;
using Timberborn.MapEditorScene;

namespace TimberApi;

public class SceneManager
{
    public delegate void SceneChangedCallback(Scene previousScene, Scene currentScene);

    public static Scene PreviousScene { get; private set; }

    public static Scene CurrentScene { get; private set; } = Scene.Unknown;

    public static event SceneChangedCallback SceneChanged = delegate { };

    internal static void Patch(Harmony harmony)
    {
        harmony.Patch(
            harmony.GetMethodInfo<GameSceneConfigurator>("Configure"),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMasterSceneConfigurator))
        );

        harmony.Patch(
            harmony.GetMethodInfo<MainMenuSceneConfigurator>(nameof(MainMenuSceneConfigurator.Configure)),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMainMenuSceneConfigurator))
        );

        harmony.Patch(
            harmony.GetMethodInfo<MapEditorSceneConfigurator>(nameof(MapEditorSceneConfigurator.Configure)),
            harmony.GetHarmonyMethod<SceneManager>(nameof(PatchMapEditorSceneConfigurator))
        );
    }

    private static void PatchMasterSceneConfigurator()
    {
        ChangeScene(Scene.Game);
    }

    private static void PatchMainMenuSceneConfigurator()
    {
        ChangeScene(Scene.MainMenu);
    }

    private static void PatchMapEditorSceneConfigurator()
    {
        ChangeScene(Scene.MapEditor);
    }

    public static void ChangeScene(Scene sceneEntrypoint)
    {
        PreviousScene = CurrentScene;
        CurrentScene = sceneEntrypoint;
        SceneChanged(PreviousScene, CurrentScene);
    }
}