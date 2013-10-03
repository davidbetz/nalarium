#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Globalization;

namespace Nalarium.Reporting
{
    public class CommonReportCreatorFactory : ReportCreatorFactory
    {
        //- @Create -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ReportCreator Create(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                switch (name.ToLower(CultureInfo.CurrentCulture))
                {
                    case "exception":
                        return new ExceptionReportCreator();
                    case "objectarray":
                        return new ObjectArrayReportCreator();
                    case "map":
                        return new MapReportCreator();
                    case "string":
                        return new StringReportCreator();
                }
            }
            //+
            return null;
        }
    }
}