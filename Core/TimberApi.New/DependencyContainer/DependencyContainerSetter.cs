using Bindito.Core;

namespace TimberApi.New.DependencyContainer
{
    public class DependencyContainerSetter
    {
        public DependencyContainerSetter(IContainer container)
        {
            DependencyContainer.Container = container;
        }
    }
}