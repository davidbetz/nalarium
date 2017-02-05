#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class ObjectArrayReportCreator : ReportCreator
    {
        //- @CreateCore -//
        /// <summary>
        ///     Generated the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override string CreateCore(object content)
        {
            var data = content as object[];
            if (data != null)
            {
                string message;
                if (IsValid(data, out message))
                {
                    Write("Information Report", FormatterType.MainHeading);
                    Write("Message", FormatterType.Heading);
                    Write(message, FormatterType.Normal);
                    Write("More Information", FormatterType.Heading);
                    for (var i = 1; i < data.Length; i++)
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