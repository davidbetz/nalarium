#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public class Int32StringKeyValue : KeyValue<int, string>
    {
        //- @Ctor -//
        public Int32StringKeyValue()
        {
        }

        public Int32StringKeyValue(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}