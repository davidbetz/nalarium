#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Collections;

namespace Nalarium
{
    public class Int32StringMap : Map<int, string>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMap" /> class.
        /// </summary>
        public Int32StringMap()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMap" /> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public Int32StringMap(params Int32StringMapEntry[] parameterArray)
        {
            AddMapEntrySeries(parameterArray);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMap" /> class.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public Int32StringMap(params string[] parameterArray)
        {
            AddPairSeries(parameterArray);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMap" /> class.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public Int32StringMap(Int32StringMap initMap)
            : base(initMap)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMap" /> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public Int32StringMap(IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (string key in dictionary.Keys)
                {
                    var k = key;
                    var v = dictionary[key] as string;
                    //+
                    if (k != null && v != null)
                    {
                        int keyInt32;
                        if (int.TryParse(k, out keyInt32))
                        {
                            Add(keyInt32, v);
                        }
                    }
                }
            }
        }

        //+
        //- Indexer -//
        public new string this[int key]
        {
            get { return base[key]; }
            set { base[key] = value; }
        }

        //+
        //- @AddCommaSeries -//
        /// <summary>
        ///     Adds the comma series.
        /// </summary>
        /// <param name="seriesMapping">The series mapping.</param>
        public void AddCommaSeries(string seriesMapping)
        {
            if (!string.IsNullOrEmpty(seriesMapping))
            {
                var parts = seriesMapping.Split(',');
                if (parts.Length > 0)
                {
                    AddPairSeries(parts);
                }
            }
        }

        //- @AddMapEntrySeries -//
        /// <summary>
        ///     Adds the map entry series.
        /// </summary>
        /// <param name="mapEntryArray">The map entry array.</param>
        public void AddMapEntrySeries(Int32StringMapEntry[] mapEntryArray)
        {
            if (mapEntryArray != null)
            {
                foreach (var mapEntry in mapEntryArray)
                {
                    AddMapEntry(mapEntry);
                }
            }
        }

        //- @AddPairSeries -//
        /// <summary>
        ///     Adds the pair series.
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public void AddPairSeries(params string[] parameterArray)
        {
            if (parameterArray != null)
            {
                foreach (var mapping in parameterArray)
                {
                    AddPair(mapping);
                }
            }
        }

        //- @AddPair -//
        /// <summary>
        ///     Adds the pair.
        /// </summary>
        /// <param name="singleMapping">The single mapping.</param>
        public void AddPair(string singleMapping)
        {
            var name = string.Empty;
            var value = string.Empty;
            var parts = singleMapping.Split('=');
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
            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Trim();
                }
                int keyInt32;
                if (int.TryParse(name.Trim(), out keyInt32))
                {
                    Add(keyInt32, value);
                }
            }
        }
    }
}