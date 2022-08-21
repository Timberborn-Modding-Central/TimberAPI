using System;
using System.Collections.Generic;
using TimberApi.Internal.LoggingSystem;
using TimberApi.Internal.SingletonSystem;
using TimberApi.Internal.SingletonSystem.Singletons;


namespace TimberApi.Internal
{
    internal class TimberApiRunner
    {
        private readonly ISingletonRepository _singletonRepository;

        private readonly IConsoleWriterInternal _consoleWriterInternal;

        public TimberApiRunner(ISingletonRepository singletonRepository, IConsoleWriterInternal consoleWriterInternal)
        {
            _singletonRepository = singletonRepository;
            _consoleWriterInternal = consoleWriterInternal;
            Run();
        }

        public void Run()
        {
            _consoleWriterInternal.Log("Starting");
            SingletonRunner(_singletonRepository.GetSingletons<IBootableSingleton>(), singleton => singleton.Boot());
            SingletonRunner(_singletonRepository.GetSingletons<IPostBootableSingleton>(), singleton => singleton.PostBoot());
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