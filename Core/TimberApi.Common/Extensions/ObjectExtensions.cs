using System;
using System.Reflection;

namespace TimberApi.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetPrivateInstanceFieldValue(this object obj, string field, object value)
        {
            obj.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance)!.SetValue(obj, value);
        }

        public static void InvokePrivateInstanceMember(this object obj, string name)
        {
            InvokePrivateInstanceMember(obj, name, Array.Empty<object>());
        }

        public static void InvokePrivateInstanceMember(this object obj, string name, object[] args)
        {
            obj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(obj, args);
        }
    }
}