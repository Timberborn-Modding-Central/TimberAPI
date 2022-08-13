using Bindito.Core;
using Timberborn.Persistence;

namespace TimberbornAPI.SpecificationSystem
{
    public class SpecificationConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ISpecificationService>().To<TimberApiSpecificationService>().AsSingleton();
        }
    }
}