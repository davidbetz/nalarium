#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Linq;
using System.Resources;
using Nalarium.Activation;

//+

namespace Nalarium.Globalization
{
    public static class ResourceAccessor
    {
        //- $ResourceConfig -//

        //+
        public const string DefaultPattern = "{AssemblyName}.{Code}";
        private static object _lock = new object();
        private static readonly Map<string, ResourceConfig> _resourceManagerWeakReferenceRegistry = new Map<string, ResourceConfig>();
        private static readonly Map<string, ResourceConfig> _resourceManagerRegistry = new Map<string, ResourceConfig>();

        //+

        //+
        /// <summary>
        ///     Loads a registered resource manager for a specific assembly.
        /// </summary>
        /// <param name="baseAssemblyName">Assembly name.</param>
        /// <param name="defaultResourceManager">
        ///     Resourcename to use if registered resource manager for specific culture is not
        ///     found.
        /// </param>
        /// <returns>
        ///     Resouce manager for assembly or specific default resource manager if registered resource manager was not
        ///     found.
        /// </returns>
        public static ResourceManager LoadResourceManager(string baseAssemblyName, ResourceManager defaultResourceManager)
        {
            //+ non-gc
            var kvp = _resourceManagerRegistry.SingleOrDefault(p => p.Key == baseAssemblyName);
            if (kvp.Value != null)
            {
                var resourceConfig = kvp.Value;
                if (resourceConfig.ResourceManager == null)
                {
                    if (kvp.Value.BuiltInCultureArray != null && kvp.Value.BuiltInCultureArray.Contains(Culture.TwoCharacterCultureCode))
                    {
                        resourceConfig.ResourceManager = defaultResourceManager;
                    }
                    else
                    {
                        resourceConfig.ResourceManager = LoadResourceManagerInternal(baseAssemblyName, defaultResourceManager);
                    }
                }
                if (resourceConfig.ResourceManager != null)
                {
                    return resourceConfig.ResourceManager;
                }
            }
            //+ gc
            kvp = _resourceManagerWeakReferenceRegistry.SingleOrDefault(p => p.Key == baseAssemblyName);
            if (kvp.Value == null)
            {
                return null;
            }
            if (kvp.Value.WeakReference.Target == null)
            {
                if (kvp.Value.BuiltInCultureArray != null && kvp.Value.BuiltInCultureArray.Contains(Culture.TwoCharacterCultureCode))
                {
                    kvp.Value.WeakReference.Target = defaultResourceManager;
                }
                else
                {
                    kvp.Value.WeakReference.Target = LoadResourceManagerInternal(baseAssemblyName, defaultResourceManager);
                }
            }
            //+
            return kvp.Value.WeakReference.Target as ResourceManager;
        }

        //- $LoadResourceManagerInternal -//
        private static ResourceManager LoadResourceManagerInternal(string baseAssemblyName, ResourceManager defaultResourceManager)
        {
            var assemblyName = DefaultPattern.Replace("{AssemblyName}", AssemblyLoader.GetShortName(baseAssemblyName)).Replace("{Code}", Culture.TwoCharacterCultureCode);
            var assembly = AssemblyLoader.Load(assemblyName);
            if (assembly == null)
            {
                return defaultResourceManager;
            }
            return new ResourceManager(assemblyName + ".Resource", assembly);
        }

        //- @RegisterResourceManager -//
        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        public static void RegisterResourceManager(string assemblyName)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, null, false);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="allowGC">
        ///     Allow resource manager to be garbage collected.  Use only when resource manager will rarely be
        ///     used.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, bool allowGC)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, null, allowGC);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="builtInCultureArray">
        ///     Culture array specifying which cultures the assembly natively supports.  If the
        ///     current culture is specified in the array, the default resource manager is automatically used and no dependency
        ///     loading will occur.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string[] builtInCultureArray)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, builtInCultureArray, false);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="builtInCultureArray">
        ///     Culture array specifying which cultures the assembly natively supports.  If the
        ///     current culture is specified in the array, the default resource manager is automatically used and no dependency
        ///     loading will occur.
        /// </param>
        /// <param name="allowGc">
        ///     Allow resource manager to be garbage collected.  Use only when resource manager will rarely be
        ///     used.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string[] builtInCultureArray, bool allowGc)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, builtInCultureArray, allowGc);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">
        ///     Pattern to use when searching for localized assembly.  The following example is also
        ///     the default: {AssemblyName}.{Code}
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string assemblyNamePattern)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, null, false);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">
        ///     Pattern to use when searching for localized assembly.  The following example is also
        ///     the default: {AssemblyName}.{Code}
        /// </param>
        /// <param name="allowGc">
        ///     Allow resource manager to be garbage collected.  Use only when resource manager will rarely be
        ///     used.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string assemblyNamePattern, bool allowGc)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, null, allowGc);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">
        ///     Pattern to use when searching for localized assembly.  The following example is also
        ///     the default: {AssemblyName}.{Code}
        /// </param>
        /// <param name="builtInCultureArray">
        ///     Culture array specifying which cultures the assembly natively supports.  If the
        ///     current culture is specified in the array, the default resource manager is automatically used and no dependency
        ///     loading will occur.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string assemblyNamePattern, string[] builtInCultureArray)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, builtInCultureArray, false);
        }

        /// <summary>
        ///     Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">
        ///     Pattern to use when searching for localized assembly.  The following example is also
        ///     the default: {AssemblyName}.{Code}
        /// </param>
        /// <param name="builtInCultureArray">
        ///     Culture array specifying which cultures the assembly natively supports.  If the
        ///     current culture is specified in the array, the default resource manager is automatically used and no dependency
        ///     loading will occur.
        /// </param>
        /// <param name="allowGC">
        ///     Allow resource manager to be garbage collected.  Use only when resource manager will rarely be
        ///     used.
        /// </param>
        public static void RegisterResourceManager(string assemblyName, string assemblyNamePattern, string[] builtInCultureArray, bool allowGC)
        {
            if (allowGC)
            {
                var resourceConfig = new ResourceConfig
                {
                    BuiltInCultureArray = builtInCultureArray,
                    WeakReference = new WeakReference(null)
                };
                if (_resourceManagerWeakReferenceRegistry.ContainsKey(assemblyName))
                {
                    return;
                }
                _resourceManagerWeakReferenceRegistry.Add(assemblyName, resourceConfig);
            }
            else
            {
                var resourceConfig = new ResourceConfig
                {
                    BuiltInCultureArray = builtInCultureArray
                };
                if (_resourceManagerRegistry.ContainsKey(assemblyName))
                {
                    return;
                }
                _resourceManagerRegistry.Add(assemblyName, resourceConfig);
            }
        }

        //- @GetString -//
        public static string GetString(string resourceKey, string baseAssemblyName)
        {
            return GetString(resourceKey, baseAssemblyName, null, null);
        }

        public static string GetString(string resourceKey, string baseAssemblyName, string[] builtInCultureArray)
        {
            return GetString(resourceKey, baseAssemblyName, null, builtInCultureArray);
        }

        public static string GetString(string resourceKey, string baseAssemblyName, ResourceManager defaultResourceManager)
        {
            return GetString(resourceKey, baseAssemblyName, defaultResourceManager, null);
        }

        public static string GetString(string resourceKey, string baseAssemblyName, ResourceManager defaultResourceManager, string[] builtInCultureArray)
        {
            if (!_resourceManagerRegistry.ContainsKey(baseAssemblyName) && !_resourceManagerWeakReferenceRegistry.ContainsKey(baseAssemblyName))
            {
                RegisterResourceManager(baseAssemblyName, DefaultPattern, builtInCultureArray);
            }
            var resourceManager = LoadResourceManager(baseAssemblyName, defaultResourceManager);
            if (resourceManager != null)
            {
                return resourceManager.GetString(resourceKey);
            }
            //+
            return string.Empty;
        }

        #region Nested type: ResourceConfig

        internal class ResourceConfig
        {
            //- @BuiltInCultureArray -//
            public string[] BuiltInCultureArray { get; set; }

            //- @WeakReference -//
            public WeakReference WeakReference { get; set; }

            //- @ResourceManager -//
            public ResourceManager ResourceManager { get; set; }
        }

        #endregion
    }
}