using System.Linq;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core2.Common;
using TimberApi.Core2.ModSystem;
using TimberApi.Internal.SingletonSystem.Singletons;

namespace TimberApi.Internal.AssetSystem
{
    public class AssetRepositorySeeder : ITimberApiSeeder
    {
        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly AssetRepository _assetRepository;

        private readonly IModRepository _modRepository;

        public AssetRepositorySeeder(AssetRepository assetRepository, IModRepository modRepository, IInternalConsoleWriter consoleWriter)
        {
            _assetRepository = assetRepository;
            _modRepository = modRepository;
            _consoleWriter = consoleWriter;
        }

        public void Run()
        {
            SetTimberApiAssets();
            SetModAssets();
            _consoleWriter.Log($"Added {_assetRepository.GetAll().Count()} prefixes");
        }

        private void SetTimberApiAssets()
        {
            _assetRepository.Add(TimberApiInternal.AssetInfo.Prefix, SceneEntrypoint.All, Paths.Core, TimberApiInternal.AssetInfo.Folder);
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