using Bindito.Core;

namespace TimberApi.SceneSystem
{
    internal static class TimberApiSceneManager
    {
        public delegate void SceneChangedCallback(SceneEntrypoint previousScene, SceneEntrypoint currentScene, IContainerDefinition currentContainerDefinition);

        public static SceneEntrypoint PreviousScene { get; private set; }

        public static SceneEntrypoint CurrentScene { get; private set; }

        public static event SceneChangedCallback SceneChanged = delegate { };

        public static void ChangeScene(SceneEntrypoint sceneEntrypoint, IContainerDefinition currentContainerDefinition)
        {
            PreviousScene = CurrentScene;
            CurrentScene = sceneEntrypoint;
            SceneChanged(PreviousScene, CurrentScene, currentContainerDefinition);
        }
    }
}