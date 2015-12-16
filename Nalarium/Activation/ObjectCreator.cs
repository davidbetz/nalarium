#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Reflection;

namespace Nalarium.Activation
{
    /// <summary>
    ///     Creates instances of types.
    /// </summary>
    public static class ObjectCreator
    {
        private static readonly Map<string, Type> _scannedTypeMap = new Map<string, Type>();

        //- @Create -//
        /// <summary>
        ///     Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static object Create(Type type, params object[] parameterArray)
        {
            return Activator.CreateInstance(type, parameterArray);
        }

        /// <summary>
        ///     Creates the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public static object Create(Type type, Map<string, object> map)
        {
            var obj = Activator.CreateInstance(type);
            //+
            var keyList = map.GetKeyList();
            foreach (var key in keyList)
            {
                var pi = type.GetProperty(key);
                pi.SetValue(obj, map[key], null);
            }
            //+
            return obj;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static object Create(string assemblyName, string typeName)
        {
            if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
            {
                return Activator.CreateInstance(assemblyName, typeName).Unwrap();
            }
            //+
            return null;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullTypeName">Full name of the type.</param>
        /// <returns></returns>
        public static object Create(string fullTypeName)
        {
            if (!string.IsNullOrEmpty(fullTypeName))
            {
                var comma = fullTypeName.IndexOf(",", StringComparison.OrdinalIgnoreCase);
                if (comma > -1)
                {
                    var typeName = fullTypeName.Substring(0, comma);
                    var assemblyName = fullTypeName.Substring(comma + 1, fullTypeName.Length - (comma + 1));
                    //+
                    return Create(assemblyName, typeName);
                }
            }
            //+
            return null;
        }

        //- @CreateByAssemblyScanning -//
        /// <summary>
        ///     Create a type without knowing assembly name (all assemblies are scanned; the first type matching the name is
        ///     created).
        /// </summary>
        /// <param name="typeName">Name of the type to create.</param>
        /// <returns>Created object or null if not found.</returns>
        public static object CreateByAssemblyScanning(string typeName)
        {
            return CreateByAssemblyScanning<object>(typeName);
        }

        /// <summary>
        ///     Create a type without knowing assembly name (all assemblies are scanned; the first type matching the name is
        ///     created).
        /// </summary>
        /// <typeparam name="T">Type of the object to create.</typeparam>
        /// <returns>Created object or null if not found.</returns>
        public static T CreateByAssemblyScanning<T>(string typeName) where T : class
        {
            if (_scannedTypeMap.ContainsKey(typeName))
            {
                return Create(_scannedTypeMap[typeName]) as T;
            }
            //+
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
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
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static T CreateAs<T>(params object[] parameterArray) where T : class
        {
            return Activator.CreateInstance(typeof (T), parameterArray) as T;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Type type) where T : class
        {
            return Activator.CreateInstance(type) as T;
        }

        /// <summary>
        ///     Creates as.
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
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Type type, params object[] parameterArray) where T : class
        {
            return Activator.CreateInstance(type, parameterArray) as T;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        public static T CreateAs<T>(Map<string, object> map)
        {
            var type = typeof (T);
            var obj = Activator.CreateInstance(type);
            //+
            var keyList = map.GetKeyList();
            foreach (var key in keyList)
            {
                var pi = type.GetProperty(key);
                pi.SetValue(obj, map[key], null);
            }
            //+
            return (T) obj;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(string assemblyName, string typeName) where T : class
        {
            if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName))
            {
                return Activator.CreateInstance(assemblyName, typeName).Unwrap() as T;
            }
            //+
            return null;
        }

        /// <summary>
        ///     Creates as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullTypeName">Full name of the type.</param>
        /// <returns></returns>
        public static T CreateAs<T>(string fullTypeName) where T : class
        {
            if (!string.IsNullOrEmpty(fullTypeName))
            {
                var comma = fullTypeName.IndexOf(",", StringComparison.OrdinalIgnoreCase);
                if (comma > -1)
                {
                    var typeName = fullTypeName.Substring(0, comma);
                    var assemblyName = fullTypeName.Substring(comma + 1, fullTypeName.Length - (comma + 1));
                    //+
                    return CreateAs<T>(assemblyName, typeName);
                }
            }
            //+
            return null;
        }

        //- @CreateWithNonPublicConstructorAs -//
        /// <summary>
        ///     Creates the with non public constructor as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static T CreateWithNonPublicConstructorAs<T>(string assemblyName, string typeName) where T : class
        {
            var assembly = Assembly.Load(assemblyName);
            var type = assembly.GetType(typeName);
            var ci = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            return (T) ci.Invoke(Type.EmptyTypes);
        }
    }
}