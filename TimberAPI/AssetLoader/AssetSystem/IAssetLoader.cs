namespace TimberbornAPI.AssetLoader.AssetSystem
{
    public interface IAssetLoader
    {
        T Load<T>(string path) where T : UnityEngine.Object;
        T Load<T>(string prefix, string path) where T : UnityEngine.Object;
        T Load<T>(string prefix, string[] path, string fileName, string name) where T : UnityEngine.Object;
        T[] LoadAll<T>(string path) where T : UnityEngine.Object;
        T[] LoadAll<T>(string prefix, string path) where T : UnityEngine.Object;
        T[] LoadAll<T>(string prefix, string[] path, string fileName) where T : UnityEngine.Object;
    }
}