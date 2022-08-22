namespace TimberApi.Core.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface ITimberApiPostLoadableSingleton
    {
        void PostLoad();
    }
}