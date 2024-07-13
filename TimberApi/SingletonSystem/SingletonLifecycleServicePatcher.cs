using System;
using System.Collections.Generic;
using Timberborn.SingletonSystem;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace TimberApi.SingletonSystem;

internal class SingletonLifecycleServicePatcher
{
    public static void LoadAllPrefix(ISingletonRepository ____singletonRepository)
    {
        LoadSingleton(____singletonRepository.GetSingletons<ITimberApiLoadableSingleton>(), singleton => singleton.Load());
        LoadSingleton(____singletonRepository.GetSingletons<ITimberApiPostLoadableSingleton>(), singleton => singleton.PostLoad());
    }
    
    public static void LoadSingletonsPrefix(ISingletonRepository ____singletonRepository)
    {
        LoadSingleton(____singletonRepository.GetSingletons<IEarlyLoadableSingleton>(), singleton => singleton.EarlyLoad());
    }

    public static void LoadSingletonsPostfix(ISingletonRepository ____singletonRepository)
    {
        LoadSingleton(____singletonRepository.GetSingletons<ILateLoadableSingleton>(), singleton => singleton.LateLoad());
    }
    
    private static void LoadSingleton<T>(IEnumerable<T> singletons, Action<T> action) where T : class
    {
        foreach (var singleton in singletons)
        {
            action(singleton);
        }
    }
}