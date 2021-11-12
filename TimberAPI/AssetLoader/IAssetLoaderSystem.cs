namespace TimberbornAPI.AssetLoader
{
    public interface IAssetLoaderSystem
    {
        void AddSceneAssets(string prefix, string[] assetLocation, IAssetLoaderSystem.EntryPoint assetEntryPoint);
        
        void LoadSceneAssets(IAssetLoaderSystem.EntryPoint scene);

        void UnloadSceneAssets(IAssetLoaderSystem.EntryPoint scene);

        public enum EntryPoint
        {
            Global,
            InGame,
            MainMenu,
            MapEditor
        }
    }
}