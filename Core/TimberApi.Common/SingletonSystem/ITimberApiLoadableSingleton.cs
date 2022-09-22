using Timberborn.SingletonSystem;

namespace TimberApi.Common.SingletonSystem
{
    [Singleton]
    public interface ITimberApiLoadableSingleton
    {
        void Load();
    }
}