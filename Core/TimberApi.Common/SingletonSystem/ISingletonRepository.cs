﻿using System.Collections.Generic;

namespace TimberApi.Common.SingletonSystem
{
    /// <summary>
    /// Replicate from: Timberborn SingletonSystem
    /// </summary>
    public interface ISingletonRepository
    {
        IEnumerable<T> GetSingletons<T>();
    }
}