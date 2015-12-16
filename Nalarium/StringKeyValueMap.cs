#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

namespace Nalarium
{
    public class StringKeyValueMap : Map<string, StringKeyValue>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="StringKeyValue" /> class.
        /// </summary>
        public StringKeyValueMap()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StringKeyValue" /> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public StringKeyValueMap(StringKeyValueMap initMap)
            : base(initMap)
        {
        }

        //+
        //- Indexer -//
        public new StringKeyValue this[string key]
        {
            get { return base[key]; }
            set { base[key] = value; }
        }
    }
}