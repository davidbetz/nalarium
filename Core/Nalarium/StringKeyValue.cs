#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    public class StringKeyValue : KeyValue<String, String>
    {
        //- @Ctor -//
        public StringKeyValue()
        {
        }
        public StringKeyValue(String key, String value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
