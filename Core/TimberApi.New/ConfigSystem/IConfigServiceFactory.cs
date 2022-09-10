using System.Reflection;

namespace TimberApi.New.ConfigSystem
{
    internal interface IConfigServiceFactory
    {
        IConfigService CreateWithAssemblyConfigs(Assembly assembly, string configDirectoryPath, string consoleTag);
    }
}