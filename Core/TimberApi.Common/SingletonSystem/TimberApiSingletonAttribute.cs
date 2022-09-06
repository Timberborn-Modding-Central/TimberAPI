using System;
using JetBrains.Annotations;

namespace TimberApi.Common.SingletonSystem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    [MeansImplicitUse]
    public class TimberApiSingletonAttribute : Attribute
    {
    }
}