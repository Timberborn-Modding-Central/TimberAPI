using Bindito.Core;
using Bindito.Unity;
using TimberApi.Core.LoggerSystem;
using TimberApi.Internal.Common;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Internal.LoggingSystem
{
    public class LoggingConfigurator : PrefabConfigurator
    {
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<Logger>().AsSingleton();
            containerDefinition.Bind<IConsoleWriter>().To<ConsoleWriter>().AsSingleton();
            containerDefinition.Bind<IConsoleWriterInternal>().To<ConsoleWriterInternal>().AsSingleton();
            containerDefinition.MultiBind<ILogListener>().ToInstance(GetInstanceFromPrefab<ConsoleMonitor>());
        }

        public static void Prefab(GameObject parent)
        {
            PrefabBuilder.Create<LoggingConfigurator>("LoggingConfigurator")
                .AddGameObject("ConsoleMonitor", consoleMonitor => consoleMonitor
                    .AddComponent<UIDocument>()
                    .AddComponent<KeyboardController>()
                    .AddComponent<ConsoleMonitor>())
                .FinishAndSetParent(parent);
        }
    }
}