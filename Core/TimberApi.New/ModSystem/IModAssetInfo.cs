using TimberApi.New.Common;

namespace TimberApi.New.ModSystem
{
    public interface IModAssetInfo
    {
        string Prefix { get; }

        SceneEntrypoint  SceneEntrypoint { get; }

        string Path { get; }
    }
}