using Timberborn.SingletonSystem;

namespace TimberApi.SingletonSystem;

[Singleton]
public interface ITimberApiPostLoadableSingleton
{
    void PostLoad();
}