using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PuppyBBS.Services.Util
{
    public static class ReflectionUtil
    {
        public static T GetAttribute<T>(Type type, bool inherit = false) where T : Attribute
        {
            return GetAttributes<T>(type, inherit).SingleOrDefault();
        }

        public static IEnumerable<T> GetAttributes<T>(Type type, bool inherit = false) where T : Attribute
        {
            var attrs = type.GetCustomAttributes(typeof(T), inherit);
            foreach (var attr in attrs)
            {
                if (attr is T)
                {
                    yield return (T)attr;
                }
            }
        }

        public static T GetAttribute<T>(Enum value) where T : Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            return Attribute.GetCustomAttribute(field, typeof(T)) as T;
        }

        public static string GetEnumDescription(Enum value)
        {
            return GetAttribute<DescriptionAttribute>(value)?.Description;
        }

        public static bool SimpleType(Type type)
        {
            return type == typeof(short) ||
                   type == typeof(short?) ||
                   type == typeof(ushort) ||
                   type == typeof(ushort?) ||
                   type == typeof(int) ||
                   type == typeof(int?) ||
                   type == typeof(uint) ||
                   type == typeof(uint?) ||
                   type == typeof(long) ||
                   type == typeof(long?) ||
                   type == typeof(ulong) ||
                   type == typeof(ulong?) ||
                   type == typeof(decimal) ||
                   type == typeof(decimal?) ||
                   type == typeof(byte) ||
                   type == typeof(byte?) ||
                   type == typeof(sbyte) ||
                   type == typeof(sbyte?) ||
                   type == typeof(float) ||
                   type == typeof(float?) ||
                   type == typeof(double) ||
                   type == typeof(double?) ||
                   type == typeof(bool) ||
                   type == typeof(bool?) ||
                   type == typeof(char) ||
                   type == typeof(char?) ||
                   type == typeof(string) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTime?) ||
                   type.IsEnum;
        }

        public static bool InheritFrom(Type sub, Type super)
        {
            if (sub == super)
            {
                return false;
            }

            while (sub != typeof(object) && sub != null)
            {
                if (sub == super)
                {
                    return true;
                }
                sub = sub.BaseType;
            }
            return false;
        }
    }
}
