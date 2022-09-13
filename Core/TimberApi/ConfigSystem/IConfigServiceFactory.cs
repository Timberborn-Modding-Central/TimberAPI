using System.Reflection;

namespace TimberApi.ConfigSystem
{
    internal interface IConfigServiceFactory
    {
        IConfigService CreateWithAssemblyConfigs(Assembly assembly, string configDirectoryPath, string consoleTag);
    }
}