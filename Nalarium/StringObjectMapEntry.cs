#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public class StringObjectMapEntry : MapEntry<string, object>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMapEntry" /> class.
        /// </summary>
        public StringObjectMapEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StringObjectMapEntry" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public StringObjectMapEntry(string key, object value)
            : base(key, value)
        {
        }
    }
}