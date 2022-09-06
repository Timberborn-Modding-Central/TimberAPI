using System;

namespace TimberApi.New.AssetSystem.Exceptions
{
    public class ModAssetBundleAlreadyUnloadedException : Exception
    {
        public ModAssetBundleAlreadyUnloadedException(string assetBundle) : base($"AssetBundle ({assetBundle}) is already unloaded.")
        {
        }
    }
}