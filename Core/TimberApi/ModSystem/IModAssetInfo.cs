using TimberApi.SceneSystem;

namespace TimberApi.ModSystem
{
    public interface IModAssetInfo
    {
        string Prefix { get; }

        SceneEntrypoint SceneEntrypoint { get; }

        string Path { get; }
    }
}