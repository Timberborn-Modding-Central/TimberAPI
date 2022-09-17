using System;
using System.Runtime.Serialization;

namespace TimberApi.ConfiguratorSystem
{
    internal class ConfigurationValidationException : Exception
    {
        public ConfigurationValidationException()
        {
        }

        protected ConfigurationValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ConfigurationValidationException(string message) : base(message)
        {
        }

        public ConfigurationValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}