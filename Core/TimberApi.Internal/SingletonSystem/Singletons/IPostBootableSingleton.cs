using Timberborn.SingletonSystem;

namespace TimberApi.Internal.SingletonSystem.Singletons
{
    [Singleton]
    public interface IPostBootableSingleton
    {
        void PostBoot();
    }
}