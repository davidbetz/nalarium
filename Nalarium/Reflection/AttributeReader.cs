#region Copyright

//+ Copyright � David Betz 2007-2015

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
            return ReadAssemblyAttribute(type, typeof (T)) as T;
        }

        public static T ReadAssemblyAttribute<T>(object obj) where T : Attribute
        {
            return ReadAssemblyAttribute(obj, typeof (T)) as T;
        }

        public static Attribute ReadAssemblyAttribute(Type type, Type attributeType)
        {
            var array = ReadAssemblyAttributeArray(type, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        public static Attribute ReadAssemblyAttribute(object obj, Type attributeType)
        {
            var array = ReadAssemblyAttributeArray(obj, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadTypeAttributeArray -//
        public static object[] ReadAssemblyAttributeArray<T>(object obj)
        {
            return ReadAssemblyAttributeArray(obj, typeof (T));
        }

        public static object[] ReadAssemblyAttributeArray<T>(Type type)
        {
            return ReadAssemblyAttributeArray(type, typeof (T));
        }

        public static object[] ReadAssemblyAttributeArray(object obj, Type attributeType)
        {
            return ReadAssemblyAttributeArray(obj.GetType(), attributeType);
        }

        public static object[] ReadAssemblyAttributeArray(Type type, Type attributeType)
        {
            var assembly = type.Assembly;
            object[] objectArray;
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

        public static T ReadTypeAttribute<T>(object obj) where T : Attribute
        {
            return ReadTypeAttribute(obj, typeof (T)) as T;
        }

        public static Attribute ReadTypeAttribute(object obj, Type attributeType)
        {
            return ReadTypeAttribute(obj.GetType(), attributeType);
        }

        public static Attribute ReadTypeAttribute(Type type, Type attributeType)
        {
            var array = ReadTypeAttributeArray(type, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadTypeAttributeArray -//
        public static object[] ReadTypeAttributeArray<T>(object obj)
        {
            return ReadTypeAttributeArray(obj.GetType(), typeof (T));
        }

        public static object[] ReadTypeAttributeArray<T>(Type type)
        {
            return ReadTypeAttributeArray(type, typeof (T));
        }

        public static object[] ReadTypeAttributeArray(object obj, Type attributeType)
        {
            return ReadTypeAttributeArray(obj.GetType(), attributeType);
        }

        public static object[] ReadTypeAttributeArray(Type type, Type attributeType)
        {
            object[] objectArray;
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
        public static List<MethodAttributeInformation<TAttribute>> FindMethodsWithAttribute<TAttribute>(object obj) where TAttribute : Attribute
        {
            var type = obj.GetType();
            var methodInfoList = new List<MethodAttributeInformation<TAttribute>>();
            var methodInfoArray = type.GetMethods();
            foreach (var mi in methodInfoArray)
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
            return ReadMethodAttribute(methodInfo, typeof (T)) as T;
        }

        public static Attribute ReadMethodAttribute(MethodInfo methodInfo, Type attributeType)
        {
            var array = ReadMethodAttributeArray(methodInfo, attributeType);
            if (!Collection.IsNullOrEmpty(array))
            {
                return array[0] as Attribute;
            }
            //+
            return null;
        }

        //- @ReadMethodAttributeArray -//
        public static object[] ReadMethodAttributeArray<T>(MethodInfo methodInfo)
        {
            return ReadMethodAttributeArray(methodInfo, typeof (T));
        }

        public static object[] ReadMethodAttributeArray(MethodInfo methodInfo, Type attributeType)
        {
            object[] objectArray;
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
        public static object[] ReadPropertyAttributeArray<T>(PropertyInfo propertyInfo)
        {
            return ReadPropertyAttributeArray(propertyInfo, typeof (T));
        }

        public static object[] ReadPropertyAttributeArray(PropertyInfo propertyInfo, Type attributeType)
        {
            object[] objectArray;
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