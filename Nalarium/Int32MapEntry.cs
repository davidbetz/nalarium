#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

namespace Nalarium
{
    public class Int32MapEntry : MapEntry<int, int>
    {
        //- @Ctor -//
        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32MapEntry" /> class.
        /// </summary>
        public Int32MapEntry()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Int32MapEntry" /> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Int32MapEntry(int key, int value)
            : base(key, value)
        {
        }
    }
}