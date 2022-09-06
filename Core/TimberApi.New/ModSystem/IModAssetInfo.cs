using TimberApi.New.SceneSystem;

namespace TimberApi.New.ModSystem
{
    public interface IModAssetInfo
    {
        string Prefix { get; }

        SceneEntrypoint  SceneEntrypoint { get; }

        string Path { get; }
    }
}