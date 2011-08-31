#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

//+
using System;

namespace Nalarium.Data.Cached
{
    /// <summary>
    /// Handles all common data caching.
    /// </summary>
    public static class CachedDataFactory
    {
        //+ field
        private static readonly Object _lock = new Object();
        private static readonly Map<String, Object> cache = new Map<String, Object>();

        //+
        //- @Exists -//
        /// <summary>
        /// Checks to see if a particular set of data is cached.
        /// </summary>
        /// <param name="scope">Scope of data set.</param>
        /// <param name="name">Name of data set.</param>
        /// <returns></returns>
        public static Boolean Exists(String scope, String name)
        {
            lock (_lock)
            {
                return cache.ContainsKey(ScopeTranscriber.Construct(scope, name));
            }
        }

        /// <summary>
        /// Checks to see if a particular set of data is cached.
        /// </summary>
        /// <param name="scope">Scope of data set.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data set.</param>
        /// <returns></returns>
        public static Boolean Exists(String scope, String culture, String name)
        {
            lock (_lock)
            {
                return cache.ContainsKey(ScopeTranscriber.Construct(scope, culture, name));
            }
        }

        //- @Register -//
        /// <summary>
        /// Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static Boolean Register<T>(String scope, String name, T data)
        {
            return Register(ScopeTranscriber.Construct(scope, name), data);
        }

        /// <summary>
        /// Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static Boolean Register<T>(String scope, String culture, String name, T data)
        {
            return Register(ScopeTranscriber.Construct(scope, culture, name), data);
        }

        /// <summary>
        /// Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <param name="runner">Delegate to run to create data.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static Boolean Register<T>(String scope, String name, Func<T> runner)
        {
            return Register(ScopeTranscriber.Construct(scope, name), runner);
        }

        /// <summary>
        /// Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <param name="runner">Delegate to run to create data.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static Boolean Register<T>(String scope, String culture, String name, Func<T> runner)
        {
            return Register(ScopeTranscriber.Construct(scope, culture, name), runner);
        }

        //- $Register -//
        private static Boolean Register<T>(String key, Func<T> runner)
        {
            return Register(key, runner());
        }

        private static Boolean Register<T>(String key, T data)
        {
            lock (_lock)
            {
                if (!cache.ContainsKey(key))
                {
                    cache[key] = data;
                    return true;
                }
                //+
                return false;
            }
        }

        //- @Get -//
        /// <summary>
        /// Gets a set of data from cache by scope and name.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <returns>Cached data or null if not present.</returns>
        public static T Get<T>(String scope, String name)
        {
            lock (_lock)
            {
                return cache.PeekSafely<T>(ScopeTranscriber.Construct(scope, name));
            }
        }

        /// <summary>
        /// Gets a set of data from cache by scope and name.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <returns>Cached data or null if not present.</returns>
        public static T Get<T>(String scope, String culture, String name)
        {
            lock (_lock)
            {
                return cache.PeekSafely<T>(ScopeTranscriber.Construct(scope, culture, name));
            }
        }
    }
}