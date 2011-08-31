#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;

namespace Nalarium.Reporting
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