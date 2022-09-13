using System;

namespace TimberApi.AssetSystem.Exceptions
{
    public class ModAssetNotLoadedException : Exception
    {
        public ModAssetNotLoadedException(string asset) : base($"Asset ({asset}) it not loaded")
        {
        }
    }
}