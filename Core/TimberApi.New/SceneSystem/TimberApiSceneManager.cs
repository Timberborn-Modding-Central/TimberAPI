namespace TimberApi.New.SceneSystem
{
    internal static class TimberApiSceneManager
    {
        public static SceneEntrypoint PreviousScene { get; private set; }

        public static SceneEntrypoint CurrentScene { get; private set; }

        public static void ChangeScene(SceneEntrypoint sceneEntrypoint)
        {
            PreviousScene = CurrentScene;
            CurrentScene = sceneEntrypoint;
        }
    }
}