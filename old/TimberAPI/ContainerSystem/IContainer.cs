using System;
using System.Collections.Generic;

namespace TimberbornAPI.ContainerSystem
{
    public interface IContainer
    {
        public T GetInstance<T>();

        public object GetInstance(Type type);
        
        public IEnumerable<object> GetBoundInstances();
    }
}