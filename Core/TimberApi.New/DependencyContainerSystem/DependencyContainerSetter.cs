using Bindito.Core;

namespace TimberApi.New.DependencyContainerSystem
{
    internal class DependencyContainerSetter
    {
        public DependencyContainerSetter(IContainer container)
        {
            DependencyContainer.Container = container;
        }
    }
}