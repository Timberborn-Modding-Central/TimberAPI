using System;

namespace TimberApi.AssetSystem.Exceptions
{
    public class PrefixAlreadyExistsException : Exception
    {
        public PrefixAlreadyExistsException(string prefix) : base($"Prefix {prefix} is already added")
        {
        }
    }
}