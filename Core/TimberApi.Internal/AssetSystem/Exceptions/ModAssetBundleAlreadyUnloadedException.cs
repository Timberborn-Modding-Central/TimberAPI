using System;

namespace TimberApi.Internal.AssetSystem.Exceptions
{
    public class ModAssetBundleAlreadyUnloadedException : Exception
    {
        public ModAssetBundleAlreadyUnloadedException(string assetBundle) : base($"AssetBundle ({assetBundle}) is already unloaded.")
        {
        }
    }
}