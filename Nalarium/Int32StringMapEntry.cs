#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public class Int32StringMapEntry : MapEntry<int, string>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMapEntry" /> class.
        /// </summary>
        public Int32StringMapEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32StringMapEntry" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Int32StringMapEntry(int key, string value)
            : base(key, value)
        {
        }
    }
}