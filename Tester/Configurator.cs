using Bindito.Core;
using Timberborn.AssetSystem;
using UnityEngine;

namespace Tester;

[Context("MainMenu")]
public class Configurator : IConfigurator
{
    public void Configure(IContainerDefinition containerDefinition)
    {
        Debug.LogError("SSWWAAA");
        containerDefinition.Bind<Test>().AsSingleton();
    }
}