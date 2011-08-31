#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium
{
    public class Int32StringMapEntry : MapEntry<Int32, String>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="Int32StringMapEntry"/> class.
        /// </summary>
        public Int32StringMapEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Int32StringMapEntry"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public Int32StringMapEntry(Int32 key, String value)
            : base(key, value)
        {
        }
    }
}