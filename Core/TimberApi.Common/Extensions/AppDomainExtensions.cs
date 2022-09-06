using System;
using System.Collections.Generic;
using System.Reflection;

namespace TimberApi.Common.Extensions
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypesInDomainByAttribute<TAttribute>(this AppDomain domain) where TAttribute : class
        {
            for (var assemblyIndex = 0; assemblyIndex < domain.GetAssemblies().Length; assemblyIndex++)
            {
                Assembly assembly = domain.GetAssemblies()[assemblyIndex];

                foreach (Type type in assembly.GetTypes())
                {
                    if (!type.IsDefined(typeof(TAttribute)))
                    {
                        continue;
                    }

                    yield return type;
                }
            }
        }
    }
}