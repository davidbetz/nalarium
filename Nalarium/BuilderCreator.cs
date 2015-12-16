#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Collections.Generic;

namespace Nalarium
{
    public static class BuilderCreator
    {
        private static readonly Dictionary<Type, object> ProviderCreator = new Dictionary<Type, object>();

        public static void Set<T>(IProviderCreator<T> creator) where T : class
        {

            ProviderCreator.Add(typeof(T), creator);
        }

        public static T Resolve<T>(params string[] parameterArray) where T : class
        {
            var type = typeof(T);
            if (!ProviderCreator.ContainsKey(type))
            {
                return null;
            }
            var creator = ProviderCreator[type] as IProviderCreator<T>;
            return creator?.Create(parameterArray);
        }
    }
}