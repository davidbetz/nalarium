#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    public class StringObjectMapEntry : MapEntry<String, Object>
    {
        //- @Ctor -//
        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMapEntry"/> class.
        /// </summary>
        public StringObjectMapEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringObjectMapEntry"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public StringObjectMapEntry(String key, Object value)
            : base(key, value)
        {
        }
    }
}