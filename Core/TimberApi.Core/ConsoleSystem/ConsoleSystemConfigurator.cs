using Bindito.Core;
using Bindito.Unity;
using TimberApi.Common.ConsoleSystem;
using TimberApi.Common.Helpers;
using TimberApi.ConsoleSystem;
using UnityEngine;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleSystemConfigurator : PrefabConfigurator
    {
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<IInternalConsoleWriter>().To<InternalConsoleWriter>().AsSingleton();
            containerDefinition.Bind<IConsoleWriter>().To<ConsoleWriter>().AsSingleton();
        }

        public static void Prefab(GameObject parent)
        {
            PrefabBuilder.Create<ConsoleSystemConfigurator>("ConsoleSystemConfigurator").FinishAndSetParent(parent);
        }
    }
}