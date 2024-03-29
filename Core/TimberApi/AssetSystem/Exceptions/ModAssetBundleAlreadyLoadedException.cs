﻿using System;

namespace TimberApi.AssetSystem.Exceptions
{
    public class ModAssetBundleAlreadyLoadedException : Exception
    {
        public ModAssetBundleAlreadyLoadedException(string assetBundle) : base($"AssetBundle ({assetBundle}) is already loaded.")
        {
        }
    }
}