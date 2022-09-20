using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TimberApi.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesWithInterface<TInterface>(this Assembly assembly)
        {
            return assembly.GetTypes().Where(x => typeof(TInterface).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
        }

        public static IEnumerable<Type> GetTypesByAttribute<TAttribute>(this Assembly assembly) where TAttribute : class
        {
            return assembly.GetTypes().Where(type => type.IsDefined(typeof(TAttribute)));
        }
    }
}