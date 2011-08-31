#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Collections;

namespace Nalarium
{
    public class Int32Map : Map<Int32, Int32>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Int32Map"/> class.
        /// </summary>
        public Int32Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32Map"/> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public Int32Map(params Int32MapEntry[] parameterArray)
        {
            AddMapEntrySeries(parameterArray);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32Map"/> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public Int32Map(params String[] parameterArray)
        {
            AddPairSeries(parameterArray);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32Map"/> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public Int32Map(Int32Map initMap)
            : base(initMap)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32Map"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public Int32Map(IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (String key in dictionary.Keys)
                {
                    String k = key;
                    var v = dictionary[key] as String;
                    //+
                    if (k != null && v != null)
                    {
                        Int32 keyInt32;
                        if (Int32.TryParse(k, out keyInt32))
                        {
                            Int32 valueInt32;
                            if (Int32.TryParse(v, out valueInt32))
                            {
                                base.Add(keyInt32, valueInt32);
                            }
                        }
                    }
                }
            }
        }

        //+
        //- Indexer -//
        public new Int32 this[Int32 key]
        {
            get
            {
                return PeekSafely(key);
            }
            set
            {
                base[key] = value;
            }
        }

        //+
        //- @AddCommaSeries -//
        /// <summary>
        /// Adds the comma series.
        /// </summary>
        /// <param name="seriesMapping">The series mapping.</param>
        public void AddCommaSeries(String seriesMapping)
        {
            if (!String.IsNullOrEmpty(seriesMapping))
            {
                String[] parts = seriesMapping.Split(',');
                if (parts.Length > 0)
                {
                    AddPairSeries(parts);
                }
            }
        }

        //- @AddMapEntrySeries -//
        /// <summary>
        /// Adds the map entry series.
        /// </summary>
        /// <param name="mapEntryArray">The map entry array.</param>
        public void AddMapEntrySeries(Int32MapEntry[] mapEntryArray)
        {
            if (mapEntryArray != null)
            {
                foreach (Int32MapEntry mapEntry in mapEntryArray)
                {
                    AddMapEntry(mapEntry);
                }
            }
        }

        //- @AddPairSeries -//
        /// <summary>
        /// Adds the pair series.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public void AddPairSeries(params String[] parameterArray)
        {
            if (parameterArray != null)
            {
                foreach (String mapping in parameterArray)
                {
                    AddPair(mapping);
                }
            }
        }

        //- @AddPair -//
        /// <summary>
        /// Adds the pair.
        /// </summary>
        /// <param name="singleMapping">The single mapping.</param>
        public void AddPair(String singleMapping)
        {
            String name = String.Empty;
            String value = String.Empty;
            String[] parts = singleMapping.Split('=');
            if (parts.Length == 2)
            {
                name = parts[0];
                value = parts[1];
            }
            else if (parts.Length == 1)
            {
                name = parts[0];
                value = parts[0];
            }
            //+
            if (!String.IsNullOrEmpty(name))
            {
                if (!String.IsNullOrEmpty(value))
                {
                    value = value.Trim();
                }
                Int32 keyInt32;
                if (Int32.TryParse(name.Trim(), out keyInt32))
                {
                    Int32 valueInt32;
                    if (Int32.TryParse(value, out valueInt32))
                    {
                        base.Add(keyInt32, valueInt32);
                    }
                }
            }
        }
    }
}