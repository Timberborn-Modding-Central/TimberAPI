using System.Reflection;

namespace TimberApi.New.ConfigSystem
{
    public interface IConfigServiceFactory
    {
        IConfigService CreateWithAssemblyConfigs(Assembly assembly, string configDirectoryPath, string consoleTag);
    }
}