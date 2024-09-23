using System;
using System.Collections.Generic;
using Bindito.Core;

namespace TimberApi.DependencyContainerSystem;

public class DependencyContainer
{
    private static IContainer _container = null!;

    public DependencyContainer(IContainer container)
    {
        _container = container;
    }

    public static T GetInstance<T>()
    {
        return _container.GetInstance<T>();
    }

    public static object GetInstance(Type type)
    {
        return _container.GetInstance(type);
    }

    public static IEnumerable<object> GetBoundInstances()
    {
        return _container.GetBoundInstances();
    }
}