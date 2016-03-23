#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nalarium.Reflection
{
    public class MethodReader
    {
        public static List<MethodInfo> GetMethodList(Type type, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var fn = type.FullName;
            lock (Lock)
            {
                if (!TypeMethodInfoDictionary.ContainsKey(fn))
                {
                    TypeMethodInfoDictionary.Add(fn, new List<MethodInfo>(type.GetMethods(flags)));
                }
                if (TypeMethodInfoDictionary.ContainsKey(fn))
                {
                    return TypeMethodInfoDictionary[fn];
                }
            }
            return new List<MethodInfo>();
        }

        private static readonly Dictionary<string, List<MethodInfo>> TypeMethodInfoDictionary = new Dictionary<string, List<MethodInfo>>();
        private static readonly object Lock = new object();
    }
}