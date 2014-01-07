#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Nalarium.Dynamic
{
    public static class DynamicObjectAccessor
    {
        public static T Get<T>(object single, string property)
        {
            var propertyInfo = single.GetType().GetProperty(property);
            return (T)propertyInfo.GetValue(single);
        }
        public static void Set<T>(object single, string property, T value)
        {
            var propertyInfo = single.GetType().GetProperty(property);
            propertyInfo.SetValue(single, value);
        }
        public static void Get<T>(IQueryable<object> data, string filter, string property)
        {
            var list = new List<T>();
            var single = data.FirstOrDefault();
            var propertyInfo = single.GetType().GetProperty(property);
            foreach (var item in data.Where(property))
            {
                list.Add((T)propertyInfo.GetValue(item));
            }
        }
        public static void Set<T>(IQueryable<object> data, string filter, string property, T value)
        {
            var single = data.FirstOrDefault();
            var propertyInfo = single.GetType().GetProperty(property);
            foreach (var item in data.Where(property))
            {
                propertyInfo.SetValue(item, value);
            }
        }
    }
}