using Bindito.Core;

namespace TimberApi.Internal.DependencyContainer
{
    public class DependencyContainerSetter
    {
        public DependencyContainerSetter(IContainer container)
        {
            TimberApiInternal.Container = container;
        }
    }
}