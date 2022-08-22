using Bindito.Core;
using Bindito.Unity;
using TimberApi.Core.Common;
using TimberApi.Core.ConsoleSystem;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.LoggingSystem
{
    public class LoggingConfigurator : PrefabConfigurator
    {
        public override void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<Logger>().AsSingleton();
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