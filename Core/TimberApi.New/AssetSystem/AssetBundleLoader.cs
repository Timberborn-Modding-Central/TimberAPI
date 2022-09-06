using System.Linq;
using TimberApi.Common.ConsoleSystem;
using TimberApi.New.AssetSystem.Exceptions;
using TimberApi.New.Common;

namespace TimberApi.New.AssetSystem
{
    public class AssetBundleLoader
    {
        private readonly AssetRepository _assetRepository;

        private readonly IInternalConsoleWriter _consoleWriter;

        public AssetBundleLoader(AssetRepository assetRepository, IInternalConsoleWriter consoleWriter)
        {
            _assetRepository = assetRepository;
            _consoleWriter = consoleWriter;
        }

        public void Load(string prefix)
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }
            assetFolder.Load();
            _consoleWriter.Log($"Assets of prefix:{prefix} loaded");
        }

        public void LoadAll(SceneEntrypoint sceneEntrypoint)
        {
            var prefixesLoaded = 0;
            foreach (AssetFolder assetFolder in _assetRepository.GetByEntrypoint(sceneEntrypoint))
            {
                assetFolder.Load();
                prefixesLoaded++;
            }

            _consoleWriter.Log($"Assets loaded for {sceneEntrypoint}, Total prefixes loaded: {prefixesLoaded}");
        }

        public void Unload(string prefix)
        {
            if (!_assetRepository.TryGetByPrefix(prefix, out AssetFolder? assetFolder))
            {
                throw new PrefixNotFoundException(prefix);
            }
            assetFolder.Unload();
            _consoleWriter.Log($"Assets of prefix:{prefix} unloaded");

        }

        public void UnloadAll(SceneEntrypoint sceneEntrypoint)
        {
            _consoleWriter.Log(_assetRepository.GetByEntrypoint(sceneEntrypoint).Count().ToString());
            foreach (AssetFolder assetFolder in _assetRepository.GetByEntrypoint(sceneEntrypoint))
            {
                assetFolder.Unload();
            }
            _consoleWriter.Log($"Assets unloaded for {sceneEntrypoint}");
        }
    }
}