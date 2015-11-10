#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nalarium.Activation
{
    /// <summary>
    /// Creates instances of types.
    /// </summary>
    public static class ObjectCreator
    {
        private static readonly Map<String, Type> _scannedTypeMap = new Map<String, Type>();

        //- @Create -//
        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static Object Create(Type type, params Object[] parameterArray)
        {
            return Activator.CreateInstance(type, parameterArray);
        }

        /// <summary>
        /// Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public static Object Create(Type type, Map<String, Object> map)
        {
            Object obj = Activator.CreateInstance(type);
            //+
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                PropertyInfo pi = type.GetProperty(key);
                pi.SetValue(obj, map[key], null);
            }
            //+
            return obj;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Object Create(String assemblyName, String typeName)
        {
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(typeName))
            {
                return Activator.CreateInstance(assemblyName, typeName).Unwrap();
            }
            //+
            return null;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullTypeName">Full name of the type.</param>
        /// <returns></returns>
        public static Object Create(String fullTypeName)
        {
            if (!String.IsNullOrEmpty(fullTypeName))
            {
                Int32 comma = fullTypeName.IndexOf(",", StringComparison.OrdinalIgnoreCase);
                if (comma > -1)
                {
                    String typeName = fullTypeName.Substring(0, comma);
                    String assemblyName = fullTypeName.Substring(comma + 1, fullTypeName.Length - (comma + 1));
                    //+
                    return Create(assemblyName, typeName);
                }
            }
            //+
            return null;
        }

        //- @CreateByAssemblyScanning -//
        /// <summary>
        /// Create a type without knowing assembly name (all assemblies are scanned; the first type matching the name is created).
        /// </summary>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Created object or null if not found.</returns>
        public static Object CreateByAssemblyScanning(String typeName)
        {
            return CreateByAssemblyScanning<Object>(typeName);
        }

        /// <summary>
        /// Create a type without knowing assembly name (all assemblies are scanned; the first type matching the name is created).
        /// </summary>
        /// <typeparam name="T">Type of the object to create.</typeparam>
        /// <returns>Created object or null if not found.</returns>
        public static T CreateByAssemblyScanning<T>(String typeName) where T : class
        {
            if (_scannedTypeMap.ContainsKey(typeName))
            {
                return Create(_scannedTypeMap[typeName]) as T;
            }
            //+
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                T obj = null;
                try
                {
                    obj = Create(assembly.FullName, typeName) as T;
                }
                catch
                {
                    continue;
                }
                if (obj != null)
                {
                    _scannedTypeMap.Add(typeName, obj.GetType());
                    return obj;
                }
            }
            //+
            return null;
        }

        //- @CreateAs -//
        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static T CreateAs<T>(params Object[] parameterArray) where T : class
        {
            return Activator.CreateInstance(typeof(T), parameterArray) as T;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Type type) where T : class
        {
            return Activator.CreateInstance(type) as T;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeInfo">The type info.</param>
        /// <returns></returns>
        public static T CreateAs<T>(TypeActivationInfo typeInfo) where T : class
        {
            if (typeInfo != null && typeInfo.Type != null && typeInfo.ParameterArray != null)
            {
                return Activator.CreateInstance(typeInfo.Type, typeInfo.ParameterArray) as T;
            }
            //+
            return null;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Type type, params Object[] parameterArray) where T : class
        {
            return Activator.CreateInstance(type, parameterArray) as T;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Map<String, Object> map)
        {
            Type type = typeof(T);
            Object obj = Activator.CreateInstance(type);
            //+
            List<String> keyList = map.GetKeyList();
            foreach (String key in keyList)
            {
                PropertyInfo pi = type.GetProperty(key);
                pi.SetValue(obj, map[key], null);
            }
            //+
            return (T)obj;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(String assemblyName, String typeName) where T : class
        {
            if (!String.IsNullOrEmpty(assemblyName) && !String.IsNullOrEmpty(typeName))
            {
                return Activator.CreateInstance(assemblyName, typeName).Unwrap() as T;
            }
            //+
            return null;
        }

        /// <summary>
        /// Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullTypeName">Full name of the type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(String fullTypeName) where T : class
        {
            if (!String.IsNullOrEmpty(fullTypeName))
            {
                Int32 comma = fullTypeName.IndexOf(",", StringComparison.OrdinalIgnoreCase);
                if (comma > -1)
                {
                    String typeName = fullTypeName.Substring(0, comma);
                    String assemblyName = fullTypeName.Substring(comma + 1, fullTypeName.Length - (comma + 1));
                    //+
                    return CreateAs<T>(assemblyName, typeName);
                }
            }
            //+
            return null;
        }

        //- @CreateWithNonPublicConstructorAs -//
        /// <summary>
        /// Creates the with non public constructor as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static T CreateWithNonPublicConstructorAs<T>(String assemblyName, String typeName) where T : class
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(typeName);
            ConstructorInfo ci = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            return (T)ci.Invoke(Type.EmptyTypes);
        }
    }
}