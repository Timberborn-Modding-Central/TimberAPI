using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Bindito.Core;
using TimberApi.Core.ConsoleSystem;

namespace TimberApi.Internal.ConfiguratorSystem
{
    internal class ConfiguratorRepository
    {
        private bool MainMenuConfiguratorsInitialized => false;
        public static ImmutableArray<IConfigurator> MainMenuConfigurators { get; private set; }

        private bool InGameConfiguratorsInitialized => false;
        public static ImmutableArray<IConfigurator> InGameConfigurators { get; private set; }

        private bool MapEditorConfiguratorsInitialized => false;
        public static ImmutableArray<IConfigurator> MapEditorConfigurators { get; private set; }

        private readonly IInternalConsoleWriter _consoleWriter;

        public ConfiguratorRepository(IInternalConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void SetMainMenuConfigurators(IEnumerable<IConfigurator> configurators)
        {
            if (MainMenuConfiguratorsInitialized)
            {
                throw new Exception("ConfiguratorBootstrapper already loaded");
            }
            MainMenuConfigurators = configurators.ToImmutableArray();
        }

        public void SetInGameConfigurators(IEnumerable<IConfigurator> configurators)
        {
            if (InGameConfiguratorsInitialized)
            {
                throw new Exception("ConfiguratorBootstrapper already loaded");
            }
            InGameConfigurators = configurators.ToImmutableArray();
        }

        public void SetMapEditorConfigurators(IEnumerable<IConfigurator> configurators)
        {
            if (MapEditorConfiguratorsInitialized)
            {
                throw new Exception("ConfiguratorBootstrapper already loaded");
            }
            MapEditorConfigurators = configurators.ToImmutableArray();
        }
    }
}
