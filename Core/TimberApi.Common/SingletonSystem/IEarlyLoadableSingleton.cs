using Timberborn.SingletonSystem;

namespace TimberApi.Common.SingletonSystem
{
    [Singleton]
    public interface IEarlyLoadableSingleton
    {
        void EarlyLoad();
    }
}