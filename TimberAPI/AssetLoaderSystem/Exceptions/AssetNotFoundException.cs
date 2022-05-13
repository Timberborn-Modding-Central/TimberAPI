using System;

namespace TimberbornAPI.AssetLoaderSystem.Exceptions
{
    internal class AssetNotFoundException : Exception
    {
        public readonly string Filename;

        public AssetNotFoundException(string filename)
        {
            Filename = filename;
        }
    }
}