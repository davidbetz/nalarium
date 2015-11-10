#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

//+
using System;

namespace Nalarium
{
    /// <summary>
    /// Declares that a type has a parameter map
    /// </summary>
    public interface IHasParameterMap
    {
        //- ParameterMap -//
        /// <summary>
        /// Gets or sets the parameter map.
        /// </summary>
        /// <value>The parameter map.</value>
        Map ParameterMap { get; set; }

        //- @DefaultParameter -//
        /// <summary>
        /// Name of the default parameter.
        /// </summary>
        String DefaultParameter { get; set; }
    }
}