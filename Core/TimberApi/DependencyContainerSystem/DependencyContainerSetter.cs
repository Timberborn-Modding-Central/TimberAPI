using Bindito.Core;

namespace TimberApi.DependencyContainerSystem
{
    internal class DependencyContainerSetter
    {
        public DependencyContainerSetter(IContainer container)
        {
            DependencyContainer.Container = container;
        }
    }
}