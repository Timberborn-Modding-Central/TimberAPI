using Bindito.Core;
using Bindito.Unity;
using TimberApi.Core.Common;
using TimberApi.Core.ConsoleSystem;
using Timberborn.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberApi.Core.LoggingSystem
{
    public class LoggingSystemConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<Logger>().AsSingleton();
        }
    }
}