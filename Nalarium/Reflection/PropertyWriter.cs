#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

namespace Nalarium.Reflection
{
    public class PropertyWriter
    {
        private readonly object _object;
        private readonly Type _type;

        //+
        //- @Ctor -//
        public PropertyWriter(object obj)
        {
            if (obj == null)
            {
                return;
            }
            _object = obj;
            _type = _object.GetType();
        }

        //- @Write -//
        public void Write(string propertyName, string value)
        {
            var pi = _type?.GetProperty(propertyName);
            pi?.SetValue(_object, value, null);
        }
    }
}