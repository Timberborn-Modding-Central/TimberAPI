﻿using System;
using JetBrains.Annotations;

namespace TimberApi.Core.SingletonSystem
{
    /// <summary>
    /// Replicate from: Timberborn SingletonSystem
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    [MeansImplicitUse]
    public class TimberApiSingletonAttribute : Attribute
    {
    }
}