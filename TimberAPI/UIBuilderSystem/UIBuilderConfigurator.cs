using Bindito.Core;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilderConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IUIBoxBuilder>().To<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<IUIBuilderFactory>().To<UIBuilderFactory>().AsSingleton();
            containerDefinition.Bind<IElementFactory>().To<ElementFactory>().AsSingleton();
        }
    }
}