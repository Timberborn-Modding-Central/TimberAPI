namespace TimberApi.New.ConfigSystem
{
    public interface IConfigService
    {
        T Get<T>() where T : IConfig, new();
    }
}