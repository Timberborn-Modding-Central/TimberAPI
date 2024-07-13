using Timberborn.SingletonSystem;

namespace TimberApi.SingletonSystem;

[Singleton]
public interface IEarlyLoadableSingleton
{
    void EarlyLoad();
}