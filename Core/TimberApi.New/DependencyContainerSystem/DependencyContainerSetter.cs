using Bindito.Core;

namespace TimberApi.New.DependencyContainerSystem
{
    public class DependencyContainerSetter
    {
        public DependencyContainerSetter(IContainer container)
        {
            DependencyContainer.Container = container;
        }
    }
}