using System;
using System.Runtime.Serialization;

namespace TimberApi.Internal.ModLoaderSystem.Exceptions
{
    public class MissingDependencyException : Exception
    {
        public MissingDependencyException()
        {
        }

        protected MissingDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MissingDependencyException(string message) : base(message)
        {
        }

        public MissingDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}