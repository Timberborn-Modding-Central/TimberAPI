using System;

namespace TimberApi.New.AssetSystem.Exceptions
{
    public class ModAssetNotLoadedException : Exception
    {
        public ModAssetNotLoadedException(string asset) : base($"Asset ({asset}) it not loaded")
        {
        }
    }
}