#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
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
            Object[] data = content as Object[];
            if (data != null)
            {
                String message;
                if (IsValid(data, out message))
                {
                    this.Write("Information Report", FormatterType.MainHeading);
                    this.Write("Message", FormatterType.Heading);
                    this.Write(message, FormatterType.Normal);
                    this.Write("More Information", FormatterType.Heading);
                    for (Int32 i = 1; i < data.Length; i++)
                    {
                        this.Write("Item", FormatterType.SubHeading);
                        this.Write(message, FormatterType.Normal);
                        this.Write(data[i].ToString(), FormatterType.Normal);
                    }
                }
            }
            //+
            return this.Result.ToString();
        }
    }
}