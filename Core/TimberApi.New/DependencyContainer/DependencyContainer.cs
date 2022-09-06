using System;
using System.Collections.Generic;

namespace TimberApi.New.DependencyContainer
{
    public static class DependencyContainer
    {
        internal static Bindito.Core.IContainer Container = null!;

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }

        public static object GetInstance(Type type)
        {
            return Container.GetInstance(type);
        }

        public static IEnumerable<object> GetBoundInstances()
        {
            return Container.GetBoundInstances();
        }
    }
}