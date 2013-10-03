#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Reporting
{
    public abstract class FormatterFactory : Factory
    {
        //- @Create -//
        /// <summary>
        /// Creates a formatter based on the specified alias
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract Formatter Create(String name);
    }
}