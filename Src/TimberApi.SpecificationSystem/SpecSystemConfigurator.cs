using Bindito.Core;
using UnityEngine;

namespace TimberApi.SpecificationSystem;

[Context("Game")]
[Context("MainMenu")]
[Context("MapEditor")]
internal class SpecSystemConfigurator : Configurator
{
    protected override void Configure()
    {
        Bind<BlueprintExtensionHelper>().AsSingleton();
        Bind<GeneratedSpecLoader>().AsSingleton();
    }
}