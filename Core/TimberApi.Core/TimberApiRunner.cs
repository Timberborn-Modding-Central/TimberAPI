using System;
using System.Collections.Generic;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.Core.SingletonSystem;
using TimberApi.Core.SingletonSystem.Singletons;
using TimberApi.Core2;
using TimberApi.Core2.Common;
using UnityEngine;

namespace TimberApi.Core
{
    internal class TimberApiRunner
    {
        private readonly ISingletonRepository _singletonRepository;

        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiRunner(ISingletonRepository singletonRepository, IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository, ConfigServiceFactory configServiceFactory)
        {
            _singletonRepository = singletonRepository;
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            TimberApiCore.Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiRunner).Assembly, Paths.TimberApi, "TimberAPI");
            Run();
            TimberApiCore.StartupTimer.Stop();
            _consoleWriter.Log($"Finished! Time elapsed: {TimberApiCore.StartupTimer.ElapsedMilliseconds:N0}ms, {TimberApiCore.StartupTimer.ElapsedMilliseconds / 1000d:N2}s");
        }

        public void Run()
        {
            _consoleWriter.Log("TimberAPI Core", $"TimberAPI {Versions.TimberApiVersion} - Timberborn {Versions.GameVersion}", LogType.Log);
            _modLoader.Run();
            _modRepository.LoadMods();

            SingletonRunner(_singletonRepository.GetSingletons<ITimberApiSeeder>(), singleton => singleton.Run());
            SingletonRunner(_singletonRepository.GetSingletons<ITimberApiLoadableSingleton>(), singleton => singleton.Load());
            SingletonRunner(_singletonRepository.GetSingletons<ITimberApiPostLoadableSingleton>(), singleton => singleton.PostLoad());
        }

        private static void SingletonRunner<T>(IEnumerable<T> singletons, Action<T> action) where T : class
        {
            foreach (T singleton in singletons)
            {
                action(singleton);
            }
        }
    }
}