#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Activation
{
    public class TypeActivationInfo
    {
        //- @Type -//
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; set; }

        //- @ParameterArray -//
        /// <summary>
        /// Gets or sets the parameter array.
        /// </summary>
        /// <value>The parameter array.</value>
        public Object[] ParameterArray { get; set; }

        //+
        //- @GetInfo -//
        /// <summary>
        /// Gets the info.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="parameterArray">The parameter array.</param>
        /// <returns>Created TypeInfo object</returns>
        public static TypeActivationInfo GetInfo(Type type, params Object[] parameterArray)
        {
            return new TypeActivationInfo
                   {
                       Type = type,
                       ParameterArray = parameterArray
                   };
        }
    }
}