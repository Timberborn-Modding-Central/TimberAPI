using System;

namespace TimberApi.Internal.ModLoaderSystem.Exceptions
{
    public class MultiModEntrypointException : Exception
    {
        public MultiModEntrypointException(string message) : base(message)
        {
        }
    }
}