using System;
using System.Collections.Generic;

namespace TimberbornAPI.ContainerSystem
{
    internal class ContainerHolder : IContainer
    {
        /// <summary>
        /// Holds the current active DI container
        /// </summary>
        internal static Bindito.Core.IContainer Container;
        
        public T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }

        public object GetInstance(Type type)
        {
            return Container.GetInstance(type);
        }
        
        public IEnumerable<object> GetBoundInstances()
        {
            return Container.GetBoundInstances();
        }
    }
}