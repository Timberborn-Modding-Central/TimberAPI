using Bindito.Core;
using TimberApi.SpecificationSystem;
using UnityEngine;

namespace TimberApi.BuildingSpecificationSystem;

[Context("Game")]
internal class BuildingSpecificationConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<BuildingSpecificationService>().AsSingleton();
        MultiBind<ISpecGenerator>().To<BuildingSpecificationGenerator>().AsSingleton();
        Bind<BuildingChangeApplier>().AsSingleton();
    }
}