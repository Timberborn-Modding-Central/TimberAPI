using Timberborn.SingletonSystem;

namespace TimberApi.Common.SingletonSystem
{
    [Singleton]
    public interface ILatePostLoadableSingleton
    {
        void LatePostLoad();
    }
}