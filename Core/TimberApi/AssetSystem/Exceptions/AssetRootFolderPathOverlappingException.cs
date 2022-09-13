using System;

namespace TimberApi.AssetSystem.Exceptions
{
    internal class AssetRootFolderPathOverlappingException : Exception
    {
        public AssetRootFolderPathOverlappingException(string path) : base($"Given path is already part of another prefix path. Path: {path}")
        {
        }
    }
}