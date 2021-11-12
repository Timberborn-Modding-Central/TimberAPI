using TimberbornAPI.AssetLoader.PluginSystem;

namespace TimberbornAPI.AssetLoader
{
    internal interface ILoadableAssetRepository
    {
        PluginRepository PluginRepository { get; }
    }
}