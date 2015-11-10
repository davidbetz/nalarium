#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium
{
    /// <summary>
    /// Declares that a type has a parameter array
    /// </summary>
    public interface IHasParameterArray
    {
        //- ParameterArray -//
        /// <summary>
        /// Gets or sets the parameter array.
        /// </summary>
        /// <value>The parameter array.</value>
        Object[] ParameterArray { get; set; }
    }
}