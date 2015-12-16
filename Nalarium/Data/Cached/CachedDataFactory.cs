#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

//+
using System;

namespace Nalarium.Data.Cached
{
    /// <summary>
    ///     Handles all common data caching.
    /// </summary>
    public static class CachedDataFactory
    {
        //+ field
        private static readonly object _lock = new object();
        private static readonly Map<string, object> cache = new Map<string, object>();

        //+
        //- @Exists -//
        /// <summary>
        ///     Checks to see if a particular set of data is cached.
        /// </summary>
        /// <param name="scope">Scope of data set.</param>
        /// <param name="name">Name of data set.</param>
        /// <returns></returns>
        public static bool Exists(string scope, string name)
        {
            lock (_lock)
            {
                return cache.ContainsKey(ScopeTranscriber.Construct(scope, name));
            }
        }

        /// <summary>
        ///     Checks to see if a particular set of data is cached.
        /// </summary>
        /// <param name="scope">Scope of data set.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data set.</param>
        /// <returns></returns>
        public static bool Exists(string scope, string culture, string name)
        {
            lock (_lock)
            {
                return cache.ContainsKey(ScopeTranscriber.Construct(scope, culture, name));
            }
        }

        //- @Register -//
        /// <summary>
        ///     Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static bool Register<T>(string scope, string name, T data)
        {
            return Register(ScopeTranscriber.Construct(scope, name), data);
        }

        /// <summary>
        ///     Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static bool Register<T>(string scope, string culture, string name, T data)
        {
            return Register(ScopeTranscriber.Construct(scope, culture, name), data);
        }

        /// <summary>
        ///     Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <param name="runner">Delegate to run to create data.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static bool Register<T>(string scope, string name, Func<T> runner)
        {
            return Register(ScopeTranscriber.Construct(scope, name), runner);
        }

        /// <summary>
        ///     Registers a particular set of data is cached.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <param name="data">Data to cache.</param>
        /// <param name="runner">Delegate to run to create data.</param>
        /// <returns>True if added, false if it was already present.</returns>
        public static bool Register<T>(string scope, string culture, string name, Func<T> runner)
        {
            return Register(ScopeTranscriber.Construct(scope, culture, name), runner);
        }

        //- $Register -//
        private static bool Register<T>(string key, Func<T> runner)
        {
            return Register(key, runner());
        }

        private static bool Register<T>(string key, T data)
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
        ///     Gets a set of data from cache by scope and name.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="name">Name of data.</param>
        /// <returns>Cached data or null if not present.</returns>
        public static T Get<T>(string scope, string name)
        {
            lock (_lock)
            {
                return cache.Get<T>(ScopeTranscriber.Construct(scope, name));
            }
        }

        /// <summary>
        ///     Gets a set of data from cache by scope and name.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="scope">Scope of data.</param>
        /// <param name="culture">Two letter culture code.</param>
        /// <param name="name">Name of data.</param>
        /// <returns>Cached data or null if not present.</returns>
        public static T Get<T>(string scope, string culture, string name)
        {
            lock (_lock)
            {
                return cache.Get<T>(ScopeTranscriber.Construct(scope, culture, name));
            }
        }
    }
}