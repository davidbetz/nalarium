#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    /// <summary>
    ///     A key/value-like structure for use with Map types.
    /// </summary>
    /// <typeparam name="T1">The type of the key.</typeparam>
    /// <typeparam name="T2">The type of the value.</typeparam>
    public class MapEntry<T1, T2>
    {
        //- @Source -//

        //+
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry&lt;T1, T2&gt;" /> class.
        /// </summary>
        public MapEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry&lt;T1, T2&gt;" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public MapEntry(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public T1 Key { get; set; }

        //- @Target -//
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T2 Value { get; set; }

        //- @Create -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry&lt;T1, T2&gt;" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Initialized map entry.</returns>
        public static MapEntry<T1, T2> Create(T1 key, T2 value)
        {
            return new MapEntry<T1, T2>(key, value);
        }
    }

    public class MapEntry : MapEntry<string, string>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry" /> class.
        /// </summary>
        public MapEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public MapEntry(string key, string value)
            : base(key, value)
        {
            //+ blank
        }

        //- @Create -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="MapEntry&lt;T1, T2&gt;" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Initialized map entry.</returns>
        public new static MapEntry Create(string key, string value)
        {
            return new MapEntry(key, value);
        }
    }
}