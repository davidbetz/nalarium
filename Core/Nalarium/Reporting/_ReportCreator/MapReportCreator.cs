#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Collections.Generic;
//+
namespace Nalarium.Reporting
{
    public class MapReportCreator : ReportCreator
    {
        //- @CreateHeader -//
        /// <summary>
        /// Creates the report header.
        /// </summary>
        protected override void CreateHeader()
        {
            this.Write("Information Report", FormatterType.MainHeading);
            this.Write("Items", FormatterType.Heading);
        }

        //- #CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            Map data = content as Map;
            if (data != null)
            {
                this.Write("Item", FormatterType.SubHeading);
                List<String> keyList = data.GetKeyList();
                foreach (String key in keyList)
                {
                    this.Write(key + ": " + data[key], FormatterType.Normal);
                    this.Write(FormatterType.Break);
                }
            }
            //+
            return this.Result.ToString();
        }
    }
}