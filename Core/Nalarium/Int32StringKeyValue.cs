#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    public class Int32StringKeyValue : KeyValue<Int32, String>
    {
        //- @Ctor -//
        public Int32StringKeyValue()
        {
        }

        public Int32StringKeyValue(Int32 key, String value)
        {
            Key = key;
            Value = value;
        }
    }
}