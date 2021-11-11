using Bindito.Core;

namespace TimberbornAPI.UIBuilderSystem
{
    public class UIBuilderConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IUIBoxBuilder>().To<UIBoxBuilder>().AsTransient();
            containerDefinition.Bind<IUIBuilder>().To<UIBuilder>().AsSingleton();
            containerDefinition.Bind<IElementFactory>().To<ElementFactory>().AsSingleton();
        }
    }
}