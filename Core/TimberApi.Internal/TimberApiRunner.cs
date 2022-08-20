using System.IO;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Internal.ModLoaderSystem;

namespace TimberApi.Internal
{
    internal class TimberApiRunner
    {
        private readonly IConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiRunner(IConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository)
        {
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            Run();
        }

        public void Run()
        {
            File.WriteAllText("keke.txt", _consoleWriter.ToString());
            _consoleWriter.Log("[TimberAPI] Installing complete, starting version: " + TimberApiVersions.TimberApiVersion);
            _modRepository.SetMods(_modLoader.Run());
        }
    }
}