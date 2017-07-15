#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Collections.Generic;

namespace Nalarium
{
    public static class AbstractFactory
    {
        private static readonly Dictionary<Type, object> ProviderFactories = new Dictionary<Type, object>();

        public static void Set<T>(IProviderFactory<T> factory) where T : class
        {
            ProviderFactories.Add(typeof(T), factory);
        }

        public static void Remove<T>() where T : class
        {
            ProviderFactories.Remove(typeof(T));
        }

        public static T Resolve<T>(params string[] parameterArray) where T : class
        {
            var type = typeof(T);
            if (!ProviderFactories.ContainsKey(type))
            {
                return null;
            }
            var factory = ProviderFactories[type] as IProviderFactory<T>;
            return factory?.Create(parameterArray);
        }
    }
}