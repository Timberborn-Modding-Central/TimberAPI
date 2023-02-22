using System;
using System.Reflection;

namespace TimberApi.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetPrivateInstanceFieldValue(this object obj, string field, object? value)
        {
            obj.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance)!.SetValue(obj, value);
        }

        public static T GetPrivateInstanceFieldValue<T>(this object obj, string field)
        {
            return (T)obj.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(obj);
        }

        public static void SetPrivateInstancePropertyValue(this object obj, string field, object? value)
        {
            obj.GetType().GetProperty(field)!.SetValue(obj, value);
        }

        public static void InvokePrivateInstanceMember(this object obj, string name)
        {
            InvokePrivateInstanceMember(obj, name, Array.Empty<object>());
        }

        public static void InvokePrivateInstanceMember(this object obj, string name, object[] args)
        {
            obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(obj, args);
        }

        public static T InvokePrivateInstanceMember<T>(this object obj, string name, object[] args)
        {
            return (T)obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(obj, args);
        }
    }
}