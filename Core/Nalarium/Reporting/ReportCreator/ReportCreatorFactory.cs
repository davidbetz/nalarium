#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;

namespace Nalarium.Reporting.ReportCreator
{
    public abstract class ReportCreatorFactory : Factory
    {
        //- @Create -//
        /// <summary>
        /// Creates a specified report creator from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract ReportCreator Create(String name);
    }
}