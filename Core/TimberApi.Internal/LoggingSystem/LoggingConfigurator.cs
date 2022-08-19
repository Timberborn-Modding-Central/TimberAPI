using Bindito.Core;
using Bindito.Unity;
using TimberApi.Core.ConsoleSystem;
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
            containerDefinition.Bind<ConsoleLogger>().ToInstance(GetInstanceFromPrefab<ConsoleLogger>());
            containerDefinition.Bind<IConsoleWriter>().ToInstance(GetInstanceFromPrefab<ConsoleLogger>());
            containerDefinition.MultiBind<ILogListener>().ToInstance(GetInstanceFromPrefab<ConsoleMonitor>());
        }

        public static void Prefab(GameObject parent)
        {
            PrefabBuilder.Create<LoggingConfigurator>("LoggingConfigurator")
                .AddGameObject<ConsoleLogger>("ConsoleLogger")
                .AddGameObject("ConsoleMonitor", consoleMonitor => consoleMonitor
                    .AddComponent<UIDocument>()
                    .AddComponent<KeyboardController>()
                    .AddComponent<ConsoleMonitor>())
                .FinishAndSetParent(parent);
        }
    }
}