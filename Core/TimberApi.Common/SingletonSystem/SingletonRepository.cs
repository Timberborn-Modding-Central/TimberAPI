using System.Collections.Generic;
using System.Linq;

namespace TimberApi.Common.SingletonSystem
{
    /// <summary>
    /// Replicate from: Timberborn SingletonSystem
    /// </summary>
    public class SingletonRepository : ISingletonRepository
    {
        private readonly SingletonListener _singletonListener;

        public SingletonRepository(SingletonListener singletonListener) => _singletonListener = singletonListener;

        public IEnumerable<T> GetSingletons<T>() => _singletonListener.Collect().OfType<T>();
    }
}