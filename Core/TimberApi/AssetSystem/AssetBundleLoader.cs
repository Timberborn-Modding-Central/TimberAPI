using System.Linq;
using TimberApi.AssetSystem.Exceptions;
using TimberApi.SceneSystem;

namespace TimberApi.AssetSystem
{
    internal class AssetBundleLoader
    {
        private readonly AssetRepository _assetRepository;

        public AssetBundleLoader(AssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public void Load(string prefix)
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }

            assetFolder.Load();
            TimberApi.ConsoleWriter.Log($"Assets of prefix:{prefix} loaded");
        }

        public void LoadAll(SceneEntrypoint sceneEntrypoint)
        {
            var prefixesLoaded = 0;
            foreach (AssetFolder assetFolder in _assetRepository.GetByEntrypoint(sceneEntrypoint))
            {
                assetFolder.Load();
                prefixesLoaded++;
            }

            TimberApi.ConsoleWriter.Log($"Assets loaded for {sceneEntrypoint}, Total prefixes loaded: {prefixesLoaded}");
        }

        public void Unload(string prefix)
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }

            assetFolder.Unload();
            TimberApi.ConsoleWriter.Log($"Assets of prefix:{prefix} unloaded");
        }

        public void UnloadAll(SceneEntrypoint sceneEntrypoint)
        {
            TimberApi.ConsoleWriter.Log(_assetRepository.GetByEntrypoint(sceneEntrypoint).Count().ToString());
            foreach (AssetFolder assetFolder in _assetRepository.GetByEntrypoint(sceneEntrypoint))
            {
                assetFolder.Unload();
            }

            TimberApi.ConsoleWriter.Log($"Assets unloaded for {sceneEntrypoint}");
        }
    }
}