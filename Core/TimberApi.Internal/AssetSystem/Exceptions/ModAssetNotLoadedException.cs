using System;

namespace TimberApi.Internal.AssetSystem.Exceptions
{
    public class ModAssetNotLoadedException : Exception
    {
        public ModAssetNotLoadedException(string assetBundle) : base($"AssetBundle ({assetBundle}) is already unloaded.")
        {
        }
    }
}