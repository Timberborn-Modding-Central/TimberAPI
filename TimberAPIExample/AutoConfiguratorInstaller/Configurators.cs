using Bindito.Core;

namespace TimberAPIExample.AutoConfiguratorInstaller
{
    public interface IInGameConfigurator : IConfigurator { }

    public interface IIMainMenuConfigurator : IConfigurator { }

    public interface IEditorConfigurator : IConfigurator { }
}