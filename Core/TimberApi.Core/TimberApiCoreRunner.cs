using TimberApi.Common.ConsoleSystem;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ModLoaderSystem;
using UnityEngine;
using Paths = TimberApi.New.Common.Paths;
using Versions = TimberApi.New.Versions;

namespace TimberApi.Core
{
    internal class TimberApiCoreRunner
    {
        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiCoreRunner(IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository, ConfigServiceFactory configServiceFactory)
        {
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            TimberApiCore.Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiCoreRunner).Assembly, Paths.TimberApi, "TimberAPI");
            Run();
        }

        public void Run()
        {
            _consoleWriter.Log("TimberAPI Core", $"TimberAPI {Versions.TimberApiVersion} - Timberborn {Versions.GameVersion}", LogType.Log);
            _modLoader.Run();
            _modRepository.LoadMods();
        }
    }
}