using Timberborn.SingletonSystem;

namespace TimberApi.SingletonSystem;

[Singleton]
public interface ILatePostLoadableSingleton
{
    void LatePostLoad();
}