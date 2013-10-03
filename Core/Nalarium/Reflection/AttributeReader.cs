#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nalarium.Reflection
{
    public static class AttributeReader
    {
        //- @ReadAssemblyAttribute -//
        public static T ReadAssemblyAttribute<T>(Type type) where T : Attribute
        {
            return ReadAssemblyAttribute(type, typeof(T)) as T;
        }
        public static T ReadAssemblyAttribute<T>(Object obj) where T : Attribute
        {
            return ReadAssemblyAttribute(obj, typeof(T)) as T;
        }
        public static Attribute ReadAssemblyAttribute(Type type, Type attributeType)
        {
            Object[] array = ReadAssemblyAttributeArray(type, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }
        public static Attribute ReadAssemblyAttribute(Object obj, Type attributeType)
        {
            Object[] array = ReadAssemblyAttributeArray(obj, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadTypeAttributeArray -//
        public static Object[] ReadAssemblyAttributeArray<T>(Object obj)
        {
            return ReadAssemblyAttributeArray(obj, typeof(T));
        }
        public static Object[] ReadAssemblyAttributeArray<T>(Type type)
        {
            return ReadAssemblyAttributeArray(type, typeof(T));
        }
        public static Object[] ReadAssemblyAttributeArray(Object obj, Type attributeType)
        {
            return ReadAssemblyAttributeArray(obj.GetType(), attributeType);
        }
        public static Object[] ReadAssemblyAttributeArray(Type type, Type attributeType)
        {
            var assembly = type.Assembly;
            Object[] objectArray;
            if (attributeType == null)
            {
                objectArray = assembly.GetCustomAttributes(true);
            }
            else
            {
                objectArray = assembly.GetCustomAttributes(attributeType, true);
            }
            //+
            return objectArray;
        }


        //- @ReadTypeAttribute -//
        public static T ReadTypeAttribute<T>(Type type) where T : Attribute
        {
            return ReadTypeAttribute(type, type) as T;
        }
        public static T ReadTypeAttribute<T>(Object obj) where T : Attribute
        {
            return ReadTypeAttribute(obj, typeof(T)) as T;
        }
        public static Attribute ReadTypeAttribute(Object obj, Type attributeType)
        {
            return ReadTypeAttribute(obj.GetType(), attributeType);
        }
        public static Attribute ReadTypeAttribute(Type type, Type attributeType)
        {
            Object[] array = ReadTypeAttributeArray(type, attributeType);
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
            return ReadTypeAttributeArray(obj.GetType(), typeof(T));
        }
        public static Object[] ReadTypeAttributeArray<T>(Type type)
        {
            return ReadTypeAttributeArray(type, typeof(T));
        }
        public static Object[] ReadTypeAttributeArray(Object obj, Type attributeType)
        {
            return ReadTypeAttributeArray(obj.GetType(), attributeType);
        }
        public static Object[] ReadTypeAttributeArray(Type type, Type attributeType)
        {
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
        public static List<MethodAttributeInformation<TAttribute>> FindMethodsWithAttribute<TAttribute>(Object obj) where TAttribute : Attribute
        {
            Type type = obj.GetType();
            var methodInfoList = new List<MethodAttributeInformation<TAttribute>>();
            MethodInfo[] methodInfoArray = type.GetMethods();
            foreach (MethodInfo mi in methodInfoArray)
            {
                var attribute = ReadMethodAttribute<TAttribute>(mi);
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
        public static T ReadMethodAttribute<T>(MethodInfo methodInfo) where T : Attribute
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

        //- @ReadPropertyAttributeArray -//
        public static Object[] ReadPropertyAttributeArray<T>(PropertyInfo propertyInfo)
        {
            return ReadPropertyAttributeArray(propertyInfo, typeof(T));
        }

        public static Object[] ReadPropertyAttributeArray(PropertyInfo propertyInfo, Type attributeType)
        {
            Object[] objectArray;
            if (attributeType == null)
            {
                objectArray = propertyInfo.GetCustomAttributes(true);
            }
            else
            {
                objectArray = propertyInfo.GetCustomAttributes(attributeType, true);
            }
            //+
            return objectArray;
        }
    }
}