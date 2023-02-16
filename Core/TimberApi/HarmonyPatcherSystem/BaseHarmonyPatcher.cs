using System;
using System.Reflection;
using HarmonyLib;

namespace TimberApi.HarmonyPatcherSystem
{
    public abstract class BaseHarmonyPatcher : IHarmonyPatcher
    {
        public abstract string UniqueId { get; }

        public abstract void Apply(Harmony harmony);
        
        protected static MethodInfo GetMethodInfo(string type, string method, Type[]? parameters = null)
        {
            return AccessTools.Method(AccessTools.TypeByName(type), method, parameters);
        }

        protected static MethodInfo GetMethodInfo<T>(string methodName, Type[]? parameters = null)
        {
            return AccessTools.Method(typeof(T), methodName, parameters);
        }
        
        protected static HarmonyMethod GetHarmonyMethod<T>(string methodName, Type[]? parameters = null, int priority = -1)
        {
            return new HarmonyMethod(GetMethodInfo<T>(methodName, parameters), priority);
        }

        protected HarmonyMethod GetHarmonyMethod(string methodName, Type[]? parameters = null, int priority = -1)
        {
            var methodInfo = AccessTools.Method(GetType(), methodName, parameters);

            return new HarmonyMethod(methodInfo, priority);
        }
    }
}