#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Reflection;
//+
namespace Nalarium.Reflection
{
    public static class AttributeReader
    {
        //- @ReadTypeAttribute -//
        public static T ReadTypeAttribute<T>(Object obj) where T : System.Attribute
        {
            return ReadTypeAttribute(obj, typeof(T)) as T;
        }
        public static Attribute ReadTypeAttribute(Object obj, Type attributeType) 
        {
            Object[] array = ReadTypeAttributeArray(obj, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadTypeAttributeArray -//
        public static Object[] ReadTypeAttributeArray<T>(Object obj)
        {
            return ReadTypeAttributeArray(obj, typeof(T));
        }
        public static Object[] ReadTypeAttributeArray(Object obj, Type attributeType)
        {
            Type type = obj.GetType();
            Object[] objectArray;
            if (attributeType == null)
            {
                objectArray = type.GetCustomAttributes(true);
            }
            else
            {
                objectArray = type.GetCustomAttributes(attributeType, true);
            }
            //+
            return objectArray;
        }

        //- @FindMethodsWithAttribute -//
        public static List<MethodAttributeInformation<TAttribute>> FindMethodsWithAttribute<TAttribute>(Object obj) where TAttribute : System.Attribute
        {
            Type type = obj.GetType();
            List<MethodAttributeInformation<TAttribute>> methodInfoList = new List<MethodAttributeInformation<TAttribute>>();
            MethodInfo[] methodInfoArray = type.GetMethods();
            foreach (MethodInfo mi in methodInfoArray)
            {
                TAttribute attribute = ReadMethodAttribute<TAttribute>(mi);
                if (attribute == null)
                {
                    continue;
                }
                methodInfoList.Add(new MethodAttributeInformation<TAttribute>
                {
                    MethodInfo = mi,
                    Attribute = attribute
                });
            }
            //+
            return methodInfoList;
        }

        //- @ReadTypeAttribute -//
        public static T ReadMethodAttribute<T>(MethodInfo methodInfo) where T : System.Attribute
        {
            return ReadMethodAttribute(methodInfo, typeof(T)) as T;
        }
        public static Attribute ReadMethodAttribute(MethodInfo methodInfo, Type attributeType)
        {
            Object[] array = ReadMethodAttributeArray(methodInfo, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadMethodAttributeArray -//
        public static Object[] ReadMethodAttributeArray<T>(MethodInfo methodInfo)
        {
            return ReadMethodAttributeArray(methodInfo, typeof(T));
        }
        public static Object[] ReadMethodAttributeArray(MethodInfo methodInfo, Type attributeType)
        {
            Object[] objectArray;
            if (attributeType == null)
            {
                objectArray = methodInfo.GetCustomAttributes(true);
            }
            else
            {
                objectArray = methodInfo.GetCustomAttributes(attributeType, true);
            }
            //+
            return objectArray;
        }
    }
}