#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class ObjectArrayReportCreator : ReportCreator
    {
        //- @CreateCore -//
        /// <summary>
        /// Generated the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            var data = content as Object[];
            if (data != null)
            {
                String message;
                if (IsValid(data, out message))
                {
                    Write("Information Report", FormatterType.MainHeading);
                    Write("Message", FormatterType.Heading);
                    Write(message, FormatterType.Normal);
                    Write("More Information", FormatterType.Heading);
                    for (Int32 i = 1; i < data.Length; i++)
                    {
                        Write("Item", FormatterType.SubHeading);
                        Write(message, FormatterType.Normal);
                        Write(data[i].ToString(), FormatterType.Normal);
                    }
                }
            }
            //+
            return Result.ToString();
        }
    }
}