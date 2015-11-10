#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Reflection;

namespace Nalarium.Reflection
{
    public class PropertyReader
    {
        private readonly Object _object;
        private readonly Type _type;

        //+
        //- @Ctor -//
        public PropertyReader(Object obj)
        {
            if (_object == null)
            {
                return;
            }
            _object = obj;
            _type = _object.GetType();
        }

        //- @ReadAsString -//
        public String ReadAsString(String propertyName)
        {
            return Read(propertyName) as String;
        }

        //- @Read -//
        public Object Read(String propertyName)
        {
            if (_type == null)
            {
                return String.Empty;
            }
            PropertyInfo pi = _type.GetProperty(propertyName);
            if (pi == null)
            {
                return String.Empty;
            }
            //+
            return pi.GetValue(_object, null);
        }
    }
}