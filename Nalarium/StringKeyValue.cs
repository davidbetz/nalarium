#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public class StringKeyValue : KeyValue<string, string>
    {
        //- @Ctor -//
        public StringKeyValue()
        {
        }

        public StringKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}