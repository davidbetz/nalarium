#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
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
            this.Key = key;
            this.Value = value;
        }
    }
}
