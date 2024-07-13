using System;
using System.Collections.Generic;
using Timberborn.Persistence;
using UnityEngine;

namespace TimberApi.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IObjectLoaderExtensions
    {
        public static T GetValueOrDefault<T>(this IObjectLoader objectLoader, PropertyKey<T> key, T defaultValue) where T : Component
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<int> key, int defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static float GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<float> key, float defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static bool GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<bool> key, bool defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static string GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<string> key, string defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static char GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<char> key, char defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Quaternion GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Quaternion> key, Quaternion defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Vector3 GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector3> key, Vector3 defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Vector3Int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector3Int> key, Vector3Int defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Vector2 GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector2> key, Vector2 defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Vector2Int GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Vector2Int> key, Vector2Int defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static Guid GetValueOrDefault(this IObjectLoader objectLoader, PropertyKey<Guid> key, Guid defaultValue)
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key);
        }

        public static T GetValueOrDefault<T>(this IObjectLoader objectLoader, PropertyKey<T> key, T defaultValue, IObjectSerializer<T> serializer) where T : class
        {
            return !objectLoader.Has(key) ? defaultValue : objectLoader.Get(key, serializer);
        }

        public static List<T> GetValueOrEmpty<T>(this IObjectLoader objectLoader, ListKey<T> key, IObjectSerializer<T> serializer) where T : class
        {
            return !objectLoader.Has(key) ? new List<T>() : objectLoader.Get(key, serializer);
        }

        public static List<int> GetValueOrEmpty(this IObjectLoader objectLoader, ListKey<int> key)
        {
            return !objectLoader.Has(key) ? new List<int>() : objectLoader.Get(key);
        }

        public static List<float> GetValueOrEmpty(this IObjectLoader objectLoader, ListKey<float> key)
        {
            return !objectLoader.Has(key) ? new List<float>() : objectLoader.Get(key);
        }

        public static List<bool> GetValueOrEmpty(this IObjectLoader objectLoader, ListKey<bool> key)
        {
            return !objectLoader.Has(key) ? new List<bool>() : objectLoader.Get(key);
        }

        public static List<string> GetValueOrEmpty(this IObjectLoader objectLoader, ListKey<string> key)
        {
            return !objectLoader.Has(key) ? new List<string>() : objectLoader.Get(key);
        }

        public static List<char> GetValueOrEmpty(this IObjectLoader objectLoader, ListKey<char> key)
        {
            return !objectLoader.Has(key) ? new List<char>() : objectLoader.Get(key);
        }
    }
}