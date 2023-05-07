using Timberborn.SingletonSystem;

namespace TimberApi.Common.SingletonSystem
{
    [Singleton]
    public interface ILateLoadableSingleton
    {
        void LateLoad();
    }
}