using System;
using TimberApi.Common;
using TimberApi.Common.ConsoleSystem;
using TimberApi.ConfigSystem;
using TimberApi.Core.ConfiguratorSystem;
using TimberApi.Core.ModLoaderSystem;
using UnityEngine;

namespace TimberApi.Core
{
    internal class TimberApiCoreRunner
    {
        private readonly ConfigurationRepositorySeeder _configurationRepositorySeeder;
        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiCoreRunner(IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository, IConfigServiceFactory configServiceFactory,
            ConfigurationRepositorySeeder configurationRepositorySeeder)
        {
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            _configurationRepositorySeeder = configurationRepositorySeeder;
            TimberApiCore.Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiCoreRunner).Assembly, Paths.TimberApi, "TimberAPI");
            Run();
        }

        public void Run()
        {
            _consoleWriter.Log("TimberAPI Core", $"TimberAPI {Versions.TimberApiVersion} - Timberborn {Versions.GameVersion}, loader: {Environment.GetEnvironmentVariable("TIMBER_LOADER_TYPE")}",
                LogType.Log);
            _modLoader.Run();
            _modRepository.LoadMods();
            _configurationRepositorySeeder.Run();
        }
    }
}