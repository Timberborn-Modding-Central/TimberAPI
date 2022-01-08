using Bindito.Core;

namespace TimberbornAPI.DependencySystem
{
    public interface IAutoConfiguratorInGame : IConfigurator { }

    public interface IAutoConfiguratorMainMenu : IConfigurator { }

    public interface IAutoConfiguratorMapEditor : IConfigurator { }
}