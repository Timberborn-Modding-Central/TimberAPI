using System;
using System.Collections.Generic;
using TimberApi.Core.ConsoleSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.Core.SingletonSystem;
using TimberApi.Core.SingletonSystem.Singletons;
using TimberApi.Core2;
using UnityEngine;

namespace TimberApi.Core
{
    internal class TimberApiRunner
    {
        private readonly ISingletonRepository _singletonRepository;

        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiRunner(ISingletonRepository singletonRepository, IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository)
        {
            _singletonRepository = singletonRepository;
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            Run();
        }

        public void Run()
        {
            _consoleWriter.Log("TimberAPI Core", $"TimberAPI {Versions.TimberApiVersion} - Timberborn {Versions.GameVersion}", LogType.Log);
            _modLoader.Boot();
            _modRepository.LoadMods();
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