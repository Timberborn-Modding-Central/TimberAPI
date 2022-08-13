using System;
using System.Collections.Generic;
using System.Reflection;

namespace TimberApi.Internal.Common
{
    internal static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypesInAssemblyByAttribute<TAttribute>() where TAttribute : class
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if(!type.IsDefined(typeof(TAttribute)))
                    {
                        continue;
                    }

                    yield return type;
                }
            }
        }

    }
}