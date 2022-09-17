using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Bindito.Core;

namespace TimberApi.Common.SingletonSystem
{
    /// <summary>
    ///     Replicate from: Timberborn SingletonSystem
    /// </summary>
    public class SingletonListener : IInjectionListener, IProvisionListener
    {
        private readonly List<object> _injectedSingletons = new();
        private readonly List<object> _providedSingletons = new();
        private readonly Dictionary<Type, bool> _typeCache = new();
        private ImmutableArray<object> _allSingletons;
        private bool _collected;

        void IInjectionListener.Listen(object injectee)
        {
            if (!ObjectIsSingleton(injectee))
            {
                return;
            }

            ThrowIfCollected(injectee);
            _injectedSingletons.Add(injectee);
        }

        void IProvisionListener.Listen(object injectee)
        {
            if (!ObjectIsSingleton(injectee))
            {
                return;
            }

            ThrowIfCollected(injectee);
            _providedSingletons.Add(injectee);
        }

        public IEnumerable<object> Collect()
        {
            if (!_collected)
            {
                _allSingletons = _providedSingletons.Concat(_injectedSingletons).Distinct().ToImmutableArray();
                _collected = true;
            }

            return _allSingletons;
        }

        private bool ObjectIsSingleton(object target)
        {
            Type type = target.GetType();
            bool flag1;
            if (_typeCache.TryGetValue(type, out flag1))
            {
                return flag1;
            }

            bool flag2 = TypeIsSingleton(type);
            _typeCache.Add(type, flag2);
            return flag2;
        }

        private static bool TypeIsSingleton(Type type)
        {
            if (type.GetCustomAttribute(typeof(TimberApiSingletonAttribute), true) != null)
            {
                return true;
            }

            foreach (MemberInfo element in type.GetInterfaces())
            {
                if (element.GetCustomAttribute(typeof(TimberApiSingletonAttribute), true) != null)
                {
                    return true;
                }
            }

            return false;
        }

        private void ThrowIfCollected(object injectee)
        {
            if (_collected)
            {
                throw new InvalidOperationException(string.Format("Attempting to add an instance of {0} after collecting.", injectee.GetType()));
            }
        }
    }
}