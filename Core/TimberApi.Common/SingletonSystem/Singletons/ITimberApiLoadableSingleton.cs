namespace TimberApi.Common.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface ITimberApiLoadableSingleton
    {
        void Load();
    }
}