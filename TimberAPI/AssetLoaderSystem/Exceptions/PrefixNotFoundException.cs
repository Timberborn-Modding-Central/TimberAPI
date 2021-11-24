using System;

namespace TimberbornAPI.AssetLoaderSystem.Exceptions
{
    internal class PrefixNotFoundException : Exception
    {
        public readonly string Prefix;

        public PrefixNotFoundException(string prefix)
        {
            Prefix = prefix;
        }
    }
}