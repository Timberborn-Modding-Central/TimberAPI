using Timberborn.SingletonSystem;

namespace TimberApi.SingletonSystem;

[Singleton]
public interface ILateLoadableSingleton
{
    void LateLoad();
}