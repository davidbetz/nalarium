#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

//+
namespace Nalarium
{
    public class KeyValue<T1, T2>
    {
        //- @First -//

        //+
        //- @Ctor -//
        public KeyValue()
        {
        }

        public KeyValue(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public T1 Key { get; set; }

        //- @Second -//
        public T2 Value { get; set; }
    }
}