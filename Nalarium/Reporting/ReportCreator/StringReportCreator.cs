#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class StringReportCreator : ReportCreator
    {
        //- @CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            var data = content as String;
            if (data != null)
            {
                Write(data, FormatterType.Normal);
            }
            //+
            return Result.ToString();
        }
    }
}