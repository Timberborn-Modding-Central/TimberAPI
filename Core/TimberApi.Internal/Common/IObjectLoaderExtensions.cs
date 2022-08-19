using System;
using System.Collections.Generic;
using Timberborn.Persistence;
using UnityEngine;

namespace TimberApi.Internal.Common
{
    // ReSharper disable once InconsistentNaming
    public static class IObjectLoaderExtensions
    {
        public static T GetValueOrDefault<T>(this IObjectLoader objectLoader, PropertyKey<T> key, T defaultValue) where T : Component => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<int> key, int defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static float GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<float> key, float defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static bool GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<bool> key, bool defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static string GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<string> key, string defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static char GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<char> key, char defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Quaternion GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Quaternion> key, Quaternion defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Vector3 GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector3> key, Vector3 defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Vector3Int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector3Int> key, Vector3Int defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Vector2 GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector2> key, Vector2 defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Vector2Int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector2Int> key, Vector2Int defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static Guid GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Guid> key, Guid defaultValue) => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        public static T GetValueOrDefault<T>(this IObjectLoader objectLoader, PropertyKey<T> key, T defaultValue, IObjectSerializer<T> serializer) where T : class => !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key, serializer);
        public static List<T> GetValueOrEmpty<T>(this IObjectLoader objectLoader, ListKey<T> key, IObjectSerializer<T> serializer) where T : class => !objectLoader.Has(key) ? new List<T>() : objectLoader.Get(key, serializer);
    }
}