#region Copyright

//+ Copyright © David Betz 2007-2017

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