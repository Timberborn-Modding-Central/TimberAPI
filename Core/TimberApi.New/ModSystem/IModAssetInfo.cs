using TimberApi.Core2.Common;

namespace TimberApi.Core2.ModSystem
{
    public interface IModAssetInfo
    {
        string Prefix { get; }

        SceneEntrypoint  SceneEntrypoint { get; }

        string Path { get; }
    }
}