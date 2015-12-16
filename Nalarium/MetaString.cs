using System.Collections.Generic;
using System.Diagnostics;

namespace Nalarium
{
    [DebuggerDisplay("{Guid}, {String}")]
    public class MetaString
    {
        public MetaString()
        {
            PropertyData = new Map<string, string>();
            ObjectPropertyData = new Map<string, IEnumerable<MetaString>>();
        }

        public string Guid { get; set; }

        public string String { get; set; }

        public Map<string, string> PropertyData { get; set; }

        public Map<string, IEnumerable<MetaString>> ObjectPropertyData { get; set; }

        public static MetaString Create(string @string)
        {
            return new MetaString
            {
                Guid = GuidCreator.GetNewGuid(),
                String = @string
            };
        }

        public static MetaString Create(string guid, string @string)
        {
            return new MetaString
            {
                Guid = guid,
                String = @string
            };
        }

        public static MetaString Create(string guid, string @string, Map<string, string> map)
        {
            return new MetaString
            {
                Guid = guid,
                String = @string,
                PropertyData = map
            };
        }
    }
}