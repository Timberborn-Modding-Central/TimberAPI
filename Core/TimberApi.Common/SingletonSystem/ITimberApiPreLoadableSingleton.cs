using Timberborn.SingletonSystem;

namespace TimberApi.Common.SingletonSystem
{
    [Singleton]
    public interface ITimberApiPreLoadableSingleton
    {
        void PreLoad();
    }
}