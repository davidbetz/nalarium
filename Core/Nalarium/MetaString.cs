using System;
using System.Diagnostics;

namespace Nalarium
{
    [DebuggerDisplay("{Guid}, {String}")]
    public class MetaString
    {
        public string Guid { get; set; }

        public string String { get; set; }

        public Map PropertyData { get; set; }

        public MetaString()
        {
            PropertyData = new Map();
        }

        public static MetaString Create(string @string)
        {
            return new MetaString()
            {
                Guid = GuidCreator.GetNewGuid(),
                String = @string
            };
        }

        public static MetaString Create(string guid, string @string)
        {
            return new MetaString()
            {
                Guid = guid,
                String = @string
            };
        }

        public static MetaString Create(string guid, string @string, Map map)
        {
            return new MetaString()
            {
                Guid = guid,
                String = @string,
                PropertyData = map
            };
        }
    }
}