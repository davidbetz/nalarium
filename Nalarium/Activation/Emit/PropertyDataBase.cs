#region Copyright

//+ Copyright © David Betz 2007-2017

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
        ///     Property name.
        /// </summary>
        public string Name { get; set; }

        //- @Type -//
        /// <summary>
        ///     Property type.
        /// </summary>
        public abstract Type Type { get; set; }
    }
}