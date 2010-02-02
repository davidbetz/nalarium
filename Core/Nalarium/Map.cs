#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
//+
namespace Nalarium
{
    /// <summary>
    /// A dictionary-like structure with allows for easy interaction.
    /// </summary>
    /// <typeparam name="T1">The type of the key.</typeparam>
    /// <typeparam name="T2">The type of the value.</typeparam>
    /// <example>See Nalarium.Map type</example>
    [DataContract]
    public class Map<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();

        [DataMember]
        protected System.Collections.Generic.Dictionary<TKey, TValue> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        //+
        //-  @IsNotNullOrEmpty -//
        public static Boolean IsNotNullOrEmpty(Map<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return false;
            }
            if (dictionary.Count == 0)
            {
                return false;
            }
            //+
            return true;
        }

        //+
        //- @Add -//
        public void Add(TKey key, TValue value)
        {
            if (!Data.ContainsKey(key))
            {
                Data.Add(key, value);
            }
        }
        public void Add(TKey key, TValue value, MapDuplicateMode mode)
        {
            switch (mode)
            {
                case MapDuplicateMode.Ignore:
                    Add(key, value);
                    break;
                case MapDuplicateMode.Replace:
                    if (Data.ContainsKey(key))
                    {
                        Data[key] = value;
                    }
                    break;
                case MapDuplicateMode.Throw:
                    Data.Add(key, value);
                    break;
                default:
                    break;
            }
        }

        //- @AddIfNotPresent -//
        public Boolean AddIfNotPresent(TKey key, TValue value)
        {
            if (!Data.ContainsKey(key))
            {
                Data.Add(key, value);
                //+
                return true;
            }
            //+
            return false;
        }

        //- @ContainsKey -//
        public Boolean ContainsKey(TKey key)
        {
            if (key == null)
            {
                return false;
            }
            return Data.ContainsKey(key);
        }

        //- @Keys -//
        public ICollection<TKey> Keys
        {
            get { return Data.Keys; }
        }

        //- @Remove -//
        public Boolean Remove(TKey key)
        {
            return Data.Remove(key);
        }

        //- @TryGetValue -//
        public Boolean TryGetValue(TKey key, out TValue value)
        {
            return Data.TryGetValue(key, out value);
        }

        //- @Values -//
        public ICollection<TValue> Values
        {
            get { return Data.Values; }
        }

        //- @FindKeyForIndex -//
        public TKey FindKeyForIndex(Int32 index)
        {
            Int32 currentIndex = 0;
            foreach (TKey key in Data.Keys)
            {
                if (currentIndex++ == index)
                {
                    return key;
                }
            }
            //+
            return default(TKey);
        }

        //- @[] -//
        public virtual TValue this[TKey key]
        {
            get
            {
                if (ContainsKey(key))
                {
                    return Data[key];
                }
                //+
                return default(TValue);
            }
            set
            {
                Data[key] = value;
            }
        }

        //- @Clear -//
        public void Clear()
        {
            Data.Clear();
        }

        //- @Count -//
        public Int32 Count { get { return Data.Count; } }

        //- @GetEnumerator -//
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Data.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        //+ static
        //- @IsNullOrEmpty -//
        public static Boolean IsNullOrEmpty(Map<TKey, TValue> map)
        {
            if (map == null || map.Count == 0)
            {
                return true;
            }
            //+
            return false;
        }

        //+
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Map&lt;T1, T2&gt;"/> class with an optional generic MapEntry parameter array
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public Map(params MapEntry<TKey, TValue>[] parameterArray)
        {
            if (parameterArray != null)
            {
                foreach (MapEntry<TKey, TValue> mapEntry in parameterArray)
                {
                    this.AddMapEntry(mapEntry);
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Map&lt;T1, T2&gt;"/> class with another Map instance.
        /// </summary>
        /// <param name="initMap">The initialization map.</param>
        public Map(Map<TKey, TValue> initMap)
        {
            this.ImportMap(initMap);
        }

        //+
        //- @DataSource -//
        /// <summary>
        /// The map data as a property (same as the GetDataSource Method)
        /// </summary>
        public List<MapEntry<TKey, TValue>> DataSource
        {
            get
            {
                return GetDataSource();
            }
        }

        //+
        //- @AddMapEntry -//
        /// <summary>
        /// Adds the map entry.
        /// </summary>
        /// <param name="mapEntry">The map entry.</param>
        public void AddMapEntry(MapEntry<TKey, TValue> mapEntry)
        {
            if (mapEntry != null)
            {
                this.Add(mapEntry.Key, mapEntry.Value);
            }
        }

        //- @GetKeyList -//
        /// <summary>
        /// Gets the key list.
        /// </summary>
        /// <returns></returns>
        public List<TKey> GetKeyList()
        {
            return Data.Keys.ToList();
        }

        //- @GetValueList -//
        /// <summary>
        /// Gets the value list.
        /// </summary>
        /// <returns></returns>
        public List<TValue> GetValueList()
        {
            return Data.Values.ToList();
        }

        //- @GetValueArray -//
        /// <summary>
        /// Gets the value array.
        /// </summary>
        /// <returns></returns>
        public TValue[] GetValueArray()
        {
            return Data.Values.ToArray();
        }

        //- @ImportMap -//
        /// <summary>
        /// Appends the specific map to the current one.
        /// </summary>
        /// <param name="map">The map to import</param>
        public void ImportMap(Map<TKey, TValue> map)
        {
            if (map != null)
            {
                List<TKey> keyList = map.GetKeyList();
                foreach (TKey key in keyList)
                {
                    this.Add(key, map[key]);
                }
            }
        }

        //- @PeekSafely -//
        /// <summary>
        /// Returns a the value associated with a specific key or the default value of the type is the value doens't exist.  It's safe because an exception is not thrown.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or, if there isn't one, the default value of the value generic type.</returns>
        [Obsolete("Use indexer instead.")]
        public TValue PeekSafely(TKey key)
        {
            if (key != null)
            {
                if (this.ContainsKey(key))
                {
                    return this[key];
                }
            }
            //+
            return default(TValue);
        }

        //- @PeekSafely -//
        /// <summary>
        /// Returns a the value associated with a specific key or the default value of the type is the value doens't exist.  It's safe because an exception is not thrown.
        /// </summary>
        /// <typeparam name="T">The type to which the returning value should be cast.</typeparam>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or, if there isn't one, the default value of the value generic type.</returns>
        [Obsolete("Use Get instead.")]
        public T PeekSafely<T>(TKey key) where T : TValue
        {
            if (key != null)
            {
                if (this.ContainsKey(key))
                {
                    return (T)this[key];
                }
            }
            return default(T);
        }

        //- @Get -//
        /// <summary>
        /// Returns a the value associated with a specific key or the default value of the type is the value doens't exist.  It's safe because an exception is not thrown.
        /// </summary>
        /// <typeparam name="T">The type to which the returning value should be cast.</typeparam>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or, if there isn't one, the default value of the value generic type.</returns>
        public T Get<T>(TKey key) where T : TValue
        {
            if (key != null)
            {
                if (this.ContainsKey(key))
                {
                    return (T)this[key];
                }
            }
            return default(T);
        }

        //- @Pull - //
        /// <summary>
        /// Pulls the value associated with the key and removes the key/value pair from the map.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or, if there isn't one, the default value of the value generic type.</returns>
        public TValue Pull(TKey key)
        {
            if (key != null)
            {
                if (this.ContainsKey(key))
                {
                    TValue value = this[key];
                    this.Remove(key);
                    return value;
                }
            }
            //+
            return default(TValue);
        }

        //- @GetDataSource -//
        /// <summary>
        /// Gets the datasource from the map as a map entry list.
        /// </summary>
        /// <returns></returns>
        public List<MapEntry<TKey, TValue>> GetDataSource()
        {
            List<MapEntry<TKey, TValue>> mapEntryList = new List<MapEntry<TKey, TValue>>();
            List<TKey> keyList = this.GetKeyList();
            foreach (TKey key in keyList)
            {
                mapEntryList.Add(new MapEntry<TKey, TValue>(key, this[key]));
            }
            //+
            return mapEntryList;
        }
    }

    //+
    /// <summary>
    /// A dictionary-like structure with allows for easy interaction for string keys and values.
    /// </summary>
    /// <example>
    /// Map map = new Map("FirstName=John", "LastName=Doe");
    /// 
    /// //+ add single pair, pair series, and comma-separated series
    /// map.AddPair("UserName=JohnDoe");
    /// map.AddPairSeries("Email=johndoe@tempuri.org", "WebSite=www.tempuri.org");
    /// map.AddCommaSeries("SpouseName=Jane Doe,Birthdate=04/14/1974");
    /// 
    /// //+ template with pattern
    /// Template person = new Template("My name is {FirstName} {LastName}; {Email}; {WebSite}; {UserName}; {SpouseName}; {Birthdate}");
    /// 
    /// //+ interpolate with data with string
    /// Console.WriteLine(person.Interpolate(map));
    /// </example>
    [DataContract]
    public class Map : Map<String, String>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        public Map()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with an optional MapEntry parameter array
        /// </summary>
        /// <param name="parameterArray">An optional MapEntry parameter array.</param>
        public Map(params MapEntry[] parameterArray)
        {
            this.AddMapEntrySeries(parameterArray);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with an optional pair parameter array
        /// </summary>
        /// <param name="parameterArray">An optional pair (i.e. "a=b") parameter array.</param>
        public Map(params String[] parameterArray)
        {
            this.AddPairSeries(parameterArray);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with another Map instance.
        /// </summary>
        /// <param name="initMap">The init map.</param>
        public Map(Map initMap)
            : base(initMap)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with an IDictionary instance
        /// </summary>
        /// <param name="dictionary">The IDictionary instance used to initialize the map</param>
        public Map(System.Collections.IDictionary dictionary)
        {
            if (dictionary != null)
            {
                foreach (String key in dictionary.Keys)
                {
                    String k = key as String;
                    String v = dictionary[key] as String;
                    //+
                    if (k != null && v != null)
                    {
                        this.Add(k, v);
                    }
                }
            }
        }

        //+
        //- @AddQueryString -//
        /// <summary>
        /// Adds the pair series (a query string looks like "a=b&c=d&e=f")
        /// </summary>
        /// <param name="seriesMapping">A queryString.</param>
        public void AddQueryString(String queryString)
        {
            if (!String.IsNullOrEmpty(queryString))
            {
                String[] parts = queryString.Split('&');
                if (parts.Length > 0)
                {
                    this.AddPairSeries(parts);
                }
            }
        }

        //- @AddMapEntrySeries -//
        /// <summary>
        /// Adds the map entry series.
        /// </summary>
        /// <param name="mapEntryArray">The map entry array.</param>
        public void AddMapEntrySeries(MapEntry[] mapEntryArray)
        {
            if (mapEntryArray != null)
            {
                foreach (MapEntry mapEntry in mapEntryArray)
                {
                    this.AddMapEntry(mapEntry);
                }
            }
        }

        //- @AddPairSeries -//
        /// <summary>
        /// Adds the pair series (a pair is a "a=b" pattern)
        /// </summary>
        /// <param name="parameterArray">The parameter array.</param>
        public void AddPairSeries(params String[] parameterArray)
        {
            if (parameterArray != null)
            {
                foreach (String mapping in parameterArray)
                {
                    this.AddPair(mapping);
                }
            }
        }

        //- @AddPair -//
        /// <summary>
        /// Adds the pair (a pair is a "a=b" pattern)
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
                //+
                base.Add(name.Trim(), value);
            }
        }

        //- @Get -//
        /// <summary>
        /// Returns a case sensitive value from the map.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or String.Empty is the key doens't exist</returns>
        public String Get(String key)
        {
            return Get(key, StringComparison.Ordinal);
        }
        /// <summary>
        /// Returns a case insensitive value from the map.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <param name="stringComparison">The StringComparison value used to control string comparison.</param>
        /// <returns>The associated value of the key or String.Empty is the key doens't exist</returns>
        public String Get(String key, StringComparison stringComparison)
        {
            Func<KeyValuePair<String, String>, Boolean> keyExists = p => p.Key.Equals(key, stringComparison);
            if (Data.Any(keyExists))
            {
                return Data.First(keyExists).Value;
            }
            //+
            return String.Empty;
        }

        //- @PeekSafely -//
        /// <summary>
        /// Returns a the value associated with a specific key or the default value of the type is the value doens't exist.  It's safe because an exception is not thrown.
        /// </summary>
        /// <typeparam name="T">The type to which the returning value should be cast.</typeparam>
        /// <param name="key">The key to look up.</param>
        /// <returns>The associated value of the key or, if there isn't one, the default value of the value generic type.</returns>
        [Obsolete("Use indexer instead.")]
        public new T PeekSafely<T>(String key)
        {
            if (key != null)
            {
                if (this.ContainsKey(key))
                {
                    return Parser.Parse<T>(this[key]);
                }
            }
            return default(T);
        }
    }
}