using System;

namespace TimberApi.Core.ModLoaderSystem.Exceptions
{
    public class MultiModEntrypointException : Exception
    {
        public MultiModEntrypointException(string message) : base(message)
        {
        }
    }
}