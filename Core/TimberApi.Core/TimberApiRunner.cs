using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.Core2;
using TimberApi.Core2.Common;
using UnityEngine;

namespace TimberApi.Core
{
    internal class TimberApiRunner
    {
        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiRunner(IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository, ConfigServiceFactory configServiceFactory)
        {
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            TimberApiCore.Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiRunner).Assembly, Paths.TimberApi, "TimberAPI");
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