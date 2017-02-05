#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class StringReportCreator : ReportCreator
    {
        //- @CreateCore -//
        /// <summary>
        ///     Generates the report.
        /// </summary>
        /// <param name="content">The map.</param>
        /// <returns></returns>
        protected override string CreateCore(object content)
        {
            var data = content as string;
            if (data != null)
            {
                Write(data, FormatterType.Normal);
            }
            //+
            return Result.ToString();
        }
    }
}