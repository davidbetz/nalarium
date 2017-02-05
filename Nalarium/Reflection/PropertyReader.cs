#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Nalarium.Reflection
{
    public class PropertyReader
    {
        private readonly object _object;
        private readonly Type _type;

        //+
        //- @Ctor -//
        public PropertyReader(object obj)
        {
            if (obj == null)
            {
                return;
            }
            _object = obj;
            _type = _object.GetType();
        }

        //- @ReadAsString -//
        public string ReadAsString(string propertyName)
        {
            return Read(propertyName) as string;
        }

        //- @Read -//
        public object Read(string propertyName)
        {
            var pi = _type?.GetProperty(propertyName);
            return pi?.GetValue(_object, null);
        }

        public static List<PropertyInfo> GetPropertyList(Type type, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var fn = type.FullName;
            lock (Lock)
            {
                if (!TypePropertyInfoDictionary.ContainsKey(fn))
                {
                    TypePropertyInfoDictionary.Add(fn, new List<PropertyInfo>(type.GetProperties(flags)));
                }
                if (TypePropertyInfoDictionary.ContainsKey(fn))
                {
                    return TypePropertyInfoDictionary[fn];
                }
            }
            return new List<PropertyInfo>();
        }

        private static readonly Dictionary<string, List<PropertyInfo>> TypePropertyInfoDictionary = new Dictionary<string, List<PropertyInfo>>();
        private static readonly object Lock = new object();
    }
}