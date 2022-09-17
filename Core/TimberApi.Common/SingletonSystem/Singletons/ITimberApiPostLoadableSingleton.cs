namespace TimberApi.Common.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface ITimberApiPostLoadableSingleton
    {
        void PostLoad();
    }
}