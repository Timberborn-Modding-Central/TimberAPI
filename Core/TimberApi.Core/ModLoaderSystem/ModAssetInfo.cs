using TimberApi.Core2.Common;
using TimberApi.Core2.ModSystem;

namespace TimberApi.Core.ModLoaderSystem
{
    internal class ModAssetInfo : IModAssetInfo
    {
        public ModAssetInfo(string prefix, SceneEntrypoint sceneEntrypointEntrypoint, string path)
        {
            Prefix = prefix;
            SceneEntrypoint = sceneEntrypointEntrypoint;
            Path = path;
        }

        public string Prefix { get; set; }

        public SceneEntrypoint SceneEntrypoint { get; set; }

        public string Path { get; set; }
    }
}