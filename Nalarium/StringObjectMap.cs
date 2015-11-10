#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections;

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
            AddMapEntrySeries(parameterArray);
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
        public StringObjectMap(IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (String key in dictionary.Keys)
                {
                    String k = key;
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
            get
            {
                return base[key];
            }
            set
            {
                base[key] = value;
            }
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
                    AddMapEntry(mapEntry);
                }
            }
        }
    }
}