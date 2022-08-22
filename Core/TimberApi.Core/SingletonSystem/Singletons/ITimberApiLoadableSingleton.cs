namespace TimberApi.Core.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface ITimberApiLoadableSingleton
    {
        void Load();
    }
}