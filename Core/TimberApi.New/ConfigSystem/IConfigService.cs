namespace TimberApi.Core2.ConfigSystem
{
    public interface IConfigService
    {
        T Get<T>() where T : IConfig, new();
    }
}