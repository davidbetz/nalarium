﻿#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
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
                switch (name.ToLower(System.Globalization.CultureInfo.CurrentCulture))
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