#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System;

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
            if (_object == null)
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
            if (_type == null)
            {
                return string.Empty;
            }
            var pi = _type.GetProperty(propertyName);
            if (pi == null)
            {
                return string.Empty;
            }
            //+
            return pi.GetValue(_object, null);
        }
    }
}