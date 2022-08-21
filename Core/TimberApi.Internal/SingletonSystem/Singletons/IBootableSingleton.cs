namespace TimberApi.Internal.SingletonSystem.Singletons
{
    [TimberApiSingleton]
    public interface IBootableSingleton
    {
        void Boot();
    }
}