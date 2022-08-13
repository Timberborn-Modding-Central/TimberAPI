using System;

namespace TimberApi.Internal.Common
{
    public static class TypeExtensions
    {
        public static T CreateInstance<T>(this Type type)
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}