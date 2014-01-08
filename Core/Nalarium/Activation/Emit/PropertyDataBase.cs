#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Diagnostics;

namespace Nalarium.Activation.Emit
{
    [DebuggerDisplay("{Name}")]
    public abstract class PropertyDataBase
    {
        //- @Name -//
        /// <summary>
        /// Property name.
        /// </summary>
        public String Name { get; set; }

        //- @Type -//
        /// <summary>
        /// Property type.
        /// </summary>
        public abstract Type Type { get; set; }
    }
}