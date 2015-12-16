#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Collections;

namespace Nalarium
{
    public class StringObjectMap : Map<string, object>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMap" /> class.
        /// </summary>
        public StringObjectMap()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMap" /> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public StringObjectMap(params StringObjectMapEntry[] parameterArray)
        {
            AddMapEntrySeries(parameterArray);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMap" /> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public StringObjectMap(StringObjectMap initMap)
            : base(initMap)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMap" /> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public StringObjectMap(IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (string key in dictionary.Keys)
                {
                    var k = key;
                    var v = dictionary[key];
                    //+
                    if (k != null && v != null)
                    {
                        Add(k, v);
                    }
                }
            }
        }

        //+
        //- Indexer -//
        public new object this[string key]
        {
            get { return base[key]; }
            set { base[key] = value; }
        }

        //+
        //- @AddMapEntrySeries -//
        /// <summary>
        ///     Adds the map entry series.
        /// </summary>
        /// <param name="mapEntryArray">The map entry array.</param>
        public void AddMapEntrySeries(StringObjectMapEntry[] mapEntryArray)
        {
            if (mapEntryArray != null)
            {
                foreach (var mapEntry in mapEntryArray)
                {
                    AddMapEntry(mapEntry);
                }
            }
        }
    }
}