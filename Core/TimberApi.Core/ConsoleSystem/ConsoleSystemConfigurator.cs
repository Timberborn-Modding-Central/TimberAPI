using Bindito.Core;
using Bindito.Unity;
using TimberApi.Common.ConsoleSystem;
using TimberApi.Common.Helpers;
using TimberApi.Common.LoggingSystem;
using TimberApi.Core.LoggingSystem;
using TimberApi.New.ConsoleSystem;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.ConsoleSystem
{
    internal class ConsoleSystemConfigurator : PrefabConfigurator
    {
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.MultiBind<ILogListener>().ToInstance(GetInstanceFromPrefab<ConsoleMonitor>());
            containerDefinition.Bind<IInternalConsoleWriter>().To<InternalConsoleWriter>().AsSingleton();
            containerDefinition.Bind<IConsoleWriter>().To<ConsoleWriter>().AsSingleton();
        }

        public static void Prefab(GameObject parent)
        {
            PrefabBuilder.Create<ConsoleSystemConfigurator>("ConsoleSystemConfigurator")
                .AddGameObject("ConsoleMonitor", consoleMonitor => consoleMonitor
                    .AddComponent<UIDocument>()
                    .AddComponent<KeyboardController>()
                    .AddComponent<ConsoleMonitor>())
                .FinishAndSetParent(parent);
        }
    }
}