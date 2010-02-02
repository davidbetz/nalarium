#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
//+
using Nalarium.Activation;
//+
namespace Nalarium.Globalization
{
    public static class ResourceAccessor
    {
        //- $ResourceConfig -//
        internal class ResourceConfig
        {
            //- @BuiltInCultureArray -//
            public String[] BuiltInCultureArray { get; set; }

            //- @WeakReference -//
            public WeakReference WeakReference { get; set; }

            //- @ResourceManager -//
            public ResourceManager ResourceManager { get; set; }
        }

        //+
        private static Object _lock = new Object();
        private static Map<String, ResourceConfig> _resourceManagerWeakReferenceRegistry = new Map<String, ResourceConfig>();
        private static Map<String, ResourceConfig> _resourceManagerRegistry = new Map<String, ResourceConfig>();

        //+
        public const String DefaultPattern = "{AssemblyName}.{Code}";

        //+
        /// <summary>
        /// Loads a registered resource manager for a specific assembly.
        /// </summary>
        /// <param name="baseAssemblyName">Assembly name.</param>
        /// <param name="defaultResourceManager">Resourcename to use if registered resource manager for specific culture is not found.</param>
        /// <returns>Resouce manager for assembly or specific default resource manager if registered resource manager was not found.</returns>
        public static ResourceManager LoadResourceManager(String baseAssemblyName, ResourceManager defaultResourceManager)
        {
            //+ non-gc
            KeyValuePair<String, ResourceConfig> kvp = _resourceManagerRegistry.SingleOrDefault(p => p.Key == baseAssemblyName);
            if (kvp.Value != null)
            {
                ResourceConfig resourceConfig = kvp.Value as ResourceConfig;
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
        private static ResourceManager LoadResourceManagerInternal(String baseAssemblyName, ResourceManager defaultResourceManager)
        {
            String assemblyName = DefaultPattern.Replace("{AssemblyName}", AssemblyLoader.GetShortName(baseAssemblyName)).Replace("{Code}", Culture.TwoCharacterCultureCode);
            Assembly assembly = AssemblyLoader.Load(assemblyName);
            if (assembly == null)
            {
                return defaultResourceManager;
            }
            else
            {
                return new ResourceManager(assemblyName + ".Resource", assembly);
            }
        }

        //- @RegisterResourceManager -//
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        public static void RegisterResourceManager(String assemblyName)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, null, false);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="allowGC">Allow resource manager to be garbage collected.  Use only when resource manager will rarely be used.</param>
        public static void RegisterResourceManager(String assemblyName, Boolean allowGC)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, null, allowGC);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        public static void RegisterResourceManager(String assemblyName, String[] builtInCultureArray)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, builtInCultureArray, false);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        /// <param name="allowGC">Allow resource manager to be garbage collected.  Use only when resource manager will rarely be used.</param>
        public static void RegisterResourceManager(String assemblyName, String[] builtInCultureArray, Boolean allowGC)
        {
            RegisterResourceManager(assemblyName, DefaultPattern, builtInCultureArray, allowGC);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">Pattern to use when searching for localized assembly.  The following example is also the default: {AssemblyName}.{Code}</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        public static void RegisterResourceManager(String assemblyName, String assemblyNamePattern)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, null, false);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">Pattern to use when searching for localized assembly.  The following example is also the default: {AssemblyName}.{Code}</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        /// <param name="allowGC">Allow resource manager to be garbage collected.  Use only when resource manager will rarely be used.</param>
        public static void RegisterResourceManager(String assemblyName, String assemblyNamePattern, Boolean allowGC)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, null, allowGC);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">Pattern to use when searching for localized assembly.  The following example is also the default: {AssemblyName}.{Code}</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        public static void RegisterResourceManager(String assemblyName, String assemblyNamePattern, String[] builtInCultureArray)
        {
            RegisterResourceManager(assemblyName, assemblyNamePattern, builtInCultureArray, false);
        }
        /// <summary>
        /// Registers a resource manager to an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <param name="assemblyNamePattern">Pattern to use when searching for localized assembly.  The following example is also the default: {AssemblyName}.{Code}</param>
        /// <param name="builtInCultureArray">Culture array specifying which cultures the assembly natively supports.  If the current culture is specified in the array, the default resource manager is automatically used and no dependency loading will occur.</param>
        /// <param name="allowGC">Allow resource manager to be garbage collected.  Use only when resource manager will rarely be used.</param>
        public static void RegisterResourceManager(String assemblyName, String assemblyNamePattern, String[] builtInCultureArray, Boolean allowGC)
        {
            if (allowGC)
            {
                ResourceConfig resourceConfig = new ResourceConfig
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
                ResourceConfig resourceConfig = new ResourceConfig
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
        public static String GetString(String resourceKey, String baseAssemblyName)
        {
            return GetString(resourceKey, baseAssemblyName, null, null);
        }
        public static String GetString(String resourceKey, String baseAssemblyName, String[] builtInCultureArray)
        {
            return GetString(resourceKey, baseAssemblyName, null, builtInCultureArray);
        }
        public static String GetString(String resourceKey, String baseAssemblyName, ResourceManager defaultResourceManager)
        {
            return GetString(resourceKey, baseAssemblyName, defaultResourceManager, null);
        }
        public static String GetString(String resourceKey, String baseAssemblyName, ResourceManager defaultResourceManager, String[] builtInCultureArray)
        {
            if (!_resourceManagerRegistry.ContainsKey(baseAssemblyName) && !_resourceManagerWeakReferenceRegistry.ContainsKey(baseAssemblyName))
            {
                RegisterResourceManager(baseAssemblyName, DefaultPattern, builtInCultureArray);
            }
            ResourceManager resourceManager = LoadResourceManager(baseAssemblyName, defaultResourceManager);
            if (resourceManager != null)
            {
                return resourceManager.GetString(resourceKey);
            }
            //+
            return String.Empty;
        }
    }
}