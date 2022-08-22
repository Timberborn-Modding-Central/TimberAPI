using System;

namespace TimberApi.Core.Common
{
    internal static class TypeExtensions
    {
        public static T CreateInstance<T>(this Type type)
        {
            return (T)Activator.CreateInstance(type);
        }
    }
}