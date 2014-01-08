#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Collections.Generic;
using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class MapReportCreator : ReportCreator
    {
        //- @CreateHeader -//
        /// <summary>
        /// Creates the report header.
        /// </summary>
        protected override void CreateHeader()
        {
            Write("Information Report", FormatterType.MainHeading);
            Write("Items", FormatterType.Heading);
        }

        //- #CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            var data = content as Map;
            if (data != null)
            {
                Write("Item", FormatterType.SubHeading);
                List<String> keyList = data.GetKeyList();
                foreach (String key in keyList)
                {
                    Write(key + ": " + data[key], FormatterType.Normal);
                    Write(FormatterType.Break);
                }
            }
            //+
            return Result.ToString();
        }
    }
}