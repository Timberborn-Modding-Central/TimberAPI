using System;
using System.Collections.Generic;
using System.Linq;

namespace TimberApi.Internal.Common
{
    public static class FlagEnumExtensions
    {
        public static IEnumerable<T> GetFlags<T>(this T flagsEnumValue) where T : Enum
        {
            return Enum
                .GetValues(typeof(T))
                .Cast<T>()
                .Where(e => flagsEnumValue.HasFlag(e))
                .ToArray();
        }
    }
}