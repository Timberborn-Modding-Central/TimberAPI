using System;
using System.Reflection;
using HarmonyLib;

namespace TimberApi.HarmonySystem;

public static class HarmonyExtensions
{
    public static MethodInfo GetMethodInfo(this Harmony harmony, string type, string method, Type[]? parameters = null)
    {
        return AccessTools.Method(AccessTools.TypeByName(type), method, parameters);
    }

    public static MethodInfo GetMethodInfo<T>(this Harmony harmony, string methodName, Type[]? parameters = null)
    {
        return AccessTools.Method(typeof(T), methodName, parameters);
    }

    public static HarmonyMethod GetHarmonyMethod<T>(this Harmony harmony, string methodName, Type[]? parameters = null,
        int priority = -1)
    {
        return new HarmonyMethod(GetMethodInfo<T>(harmony, methodName, parameters), priority);
    }
}