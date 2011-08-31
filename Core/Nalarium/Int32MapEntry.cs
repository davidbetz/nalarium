#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium
{
    public class Int32MapEntry : MapEntry<Int32, Int32>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Int32MapEntry"/> class.
        /// </summary>
        public Int32MapEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32MapEntry"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Int32MapEntry(Int32 key, Int32 value)
            : base(key, value)
        {
        }
    }
}