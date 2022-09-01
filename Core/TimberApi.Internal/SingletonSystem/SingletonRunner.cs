using System;
using System.Collections.Generic;
using TimberApi.Internal.SingletonSystem.Singletons;

namespace TimberApi.Internal.SingletonSystem
{
    public class SingletonRunner
    {
        private readonly ISingletonRepository _singletonRepository;

        public SingletonRunner(ISingletonRepository singletonRepository)
        {
            _singletonRepository = singletonRepository;
            Run();
        }

        private void Run()
        {
            SingletonActivator(_singletonRepository.GetSingletons<ITimberApiSeeder>(), singleton => singleton.Run());
            SingletonActivator(_singletonRepository.GetSingletons<ITimberApiLoadableSingleton>(), singleton => singleton.Load());
            SingletonActivator(_singletonRepository.GetSingletons<ITimberApiPostLoadableSingleton>(), singleton => singleton.PostLoad());
        }

        private static void SingletonActivator<T>(IEnumerable<T> singletons, Action<T> action) where T : class
        {
            foreach (T singleton in singletons)
            {
                action(singleton);
            }
        }
    }
}