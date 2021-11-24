using System.Collections.Generic;
using System.Linq;
using TimberbornAPI.AssetLoaderSystem.Exceptions;

namespace TimberbornAPI.AssetLoaderSystem.AssetSystem
{
    internal class AssetRepository : IAssetRepository
    {
        private readonly List<CustomAssetBundle> _assetBundles;

        public AssetRepository()
        {
            _assetBundles = new List<CustomAssetBundle>();
        }

        public void Add(CustomAssetBundle customAssetBundle)
        {
            _assetBundles.Add(customAssetBundle);
        }

        public CustomAssetBundle FindByPathAndFileName(string[] path, string fileName)
        {
            CustomAssetBundle bundle = _assetBundles.FirstOrDefault(bundle => bundle.AssetPath.SequenceEqual(path) && bundle.FileName == fileName);
            if (bundle == null)
                throw new AssetNotFoundException();
            return bundle;
        }

        public IEnumerable<CustomAssetBundle> All()
        {
            return _assetBundles;
        }

        public void LoadAll()
        {
            foreach (CustomAssetBundle customAssetBundle in _assetBundles)
            {
                customAssetBundle.Load();
            }
        }

        public void UnloadAll()
        {
            foreach (CustomAssetBundle customAssetBundle in _assetBundles)
            {
                customAssetBundle.Unload();
            }
        }
    }
}