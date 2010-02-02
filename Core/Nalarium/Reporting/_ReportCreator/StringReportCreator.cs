#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright � Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Reporting
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
            String data = content as String;
            if (data != null)
            {
                this.Write(data, FormatterType.Normal);
            }
            //+
            return this.Result.ToString();
        }
    }
}