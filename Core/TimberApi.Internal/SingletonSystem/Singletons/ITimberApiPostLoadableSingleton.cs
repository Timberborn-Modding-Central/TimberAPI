namespace TimberApi.Internal.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface ITimberApiPostLoadableSingleton
    {
        void PostLoad();
    }
}