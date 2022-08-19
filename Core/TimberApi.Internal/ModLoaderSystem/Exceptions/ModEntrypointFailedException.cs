using System;
using System.Runtime.Serialization;

namespace TimberApi.Internal.ModLoaderSystem.Exceptions
{
    public class ModEntrypointFailedException : Exception
    {
        public ModEntrypointFailedException()
        {
        }

        protected ModEntrypointFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ModEntrypointFailedException(string message) : base(message)
        {
        }

        public ModEntrypointFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}