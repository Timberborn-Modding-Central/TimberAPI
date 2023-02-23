using System.Linq;
using TimberApi.Common;
using TimberApi.Common.SingletonSystem;
using TimberApi.ModSystem;
using TimberApi.SceneSystem;

namespace TimberApi.AssetSystem
{
    internal class AssetRepositoryPreLoadableSingleton : ITimberApiLoadableSingleton
    {
        private readonly AssetRepository _assetRepository;

        private readonly IModRepository _modRepository;

        public AssetRepositoryPreLoadableSingleton(AssetRepository assetRepository, IModRepository modRepository)
        {
            _assetRepository = assetRepository;
            _modRepository = modRepository;
        }

        public void Load()
        {
            SetTimberApiAssets();
            SetModAssets();
            TimberApi.ConsoleWriter.Log($"Added {_assetRepository.GetAll().Count()} prefixes");
        }

        private void SetTimberApiAssets()
        {
            _assetRepository.Add(TimberApi.AssetInfo.Prefix, SceneEntrypoint.All, Paths.Core, TimberApi.AssetInfo.Folder);
        }

        private void SetModAssets()
        {
            foreach (IMod mod in _modRepository.All())
            {
                _assetRepository.Add(mod);
            }
        }
    }
}