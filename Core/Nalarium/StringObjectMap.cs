#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium
{
    public class StringObjectMap : Map<String, Object>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMap"/> class.
        /// </summary>
        public StringObjectMap()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMap"/> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public StringObjectMap(params StringObjectMapEntry[] parameterArray)
        {
            this.AddMapEntrySeries(parameterArray);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMap"/> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public StringObjectMap(StringObjectMap initMap)
            : base(initMap)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMap"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public StringObjectMap(System.Collections.IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (String key in dictionary.Keys)
                {
                    String k = key as String;
                    Object v = dictionary[key];
                    //+
                    if (k != null && v != null)
                    {
                        base.Add(k, v);
                    }
                }
            }
        }

        //+
        //- Indexer -//
        public new Object this[String key]
        {
            get { return PeekSafely(key); }
            set { base[key] = value; }
        }

        //+
        //- @AddMapEntrySeries -//
        /// <summary>
        /// Adds the map entry series.
        /// </summary>
        /// <param name="mapEntryArray">The map entry array.</param>
        public void AddMapEntrySeries(StringObjectMapEntry[] mapEntryArray)
        {
            if (mapEntryArray != null)
            {
                foreach (StringObjectMapEntry mapEntry in mapEntryArray)
                {
                    this.AddMapEntry(mapEntry);
                }
            }
        }
    }
}