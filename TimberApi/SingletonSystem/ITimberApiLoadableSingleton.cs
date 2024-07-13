using Timberborn.SingletonSystem;

namespace TimberApi.SingletonSystem;

[Singleton]
public interface ITimberApiLoadableSingleton
{
    void Load();
}