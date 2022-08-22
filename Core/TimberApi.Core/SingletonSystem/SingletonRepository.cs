using System.Collections.Generic;
using System.Linq;

namespace TimberApi.Core.SingletonSystem
{
    /// <summary>
    /// Replicate from: Timberborn SingletonSystem
    /// </summary>
    internal class SingletonRepository : ISingletonRepository
    {
        private readonly SingletonListener _singletonListener;

        public SingletonRepository(SingletonListener singletonListener) => _singletonListener = singletonListener;

        public IEnumerable<T> GetSingletons<T>() => _singletonListener.Collect().OfType<T>();
    }
}