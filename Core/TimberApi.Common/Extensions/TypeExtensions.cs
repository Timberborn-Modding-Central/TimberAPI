using System;

namespace TimberApi.Common.Extensions
{
    public static class TypeExtensions
    {
        public static T CreateInstance<T>(this Type type)
        {
            return (T) Activator.CreateInstance(type);
        }

        public static T CreateInstance<T>(this Type type, object[] parameters)
        {
            return (T) Activator.CreateInstance(type, parameters);
        }
    }
}