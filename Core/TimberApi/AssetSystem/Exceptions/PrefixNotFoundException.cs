using System;

namespace TimberApi.AssetSystem.Exceptions
{
    public class PrefixNotFoundException : Exception
    {
        public PrefixNotFoundException(string prefix) : base($"Prefix {prefix} not found")
        {
        }
    }
}