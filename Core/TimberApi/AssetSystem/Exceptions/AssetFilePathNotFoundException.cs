using System;

namespace TimberApi.AssetSystem.Exceptions
{
    public class AssetFilePathNotFoundException : Exception
    {
        public AssetFilePathNotFoundException(string path) : base($"Path to asset bundle not found, path: {path}")
        {
        }
    }
}