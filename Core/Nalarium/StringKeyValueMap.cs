#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    public class StringKeyValueMap : Map<String, StringKeyValue>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="StringKeyValue"/> class.
        /// </summary>
        public StringKeyValueMap()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringKeyValue"/> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public StringKeyValueMap(StringKeyValueMap initMap)
            : base(initMap)
        {
        }

        //+
        //- Indexer -//
        public new StringKeyValue this[String key]
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
    }
}