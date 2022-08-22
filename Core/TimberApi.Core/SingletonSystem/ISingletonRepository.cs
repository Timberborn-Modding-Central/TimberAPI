using System.Collections.Generic;

namespace TimberApi.Core.SingletonSystem
{
    /// <summary>
    /// Replicate from: Timberborn SingletonSystem
    /// </summary>
    public interface ISingletonRepository
    {
        IEnumerable<T> GetSingletons<T>();
    }
}