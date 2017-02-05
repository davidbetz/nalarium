#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using Nalarium.Reporting.ReportCreator.Formatter;

namespace Nalarium.Reporting.ReportCreator
{
    public class MapReportCreator : ReportCreator
    {
        //- @CreateHeader -//
        /// <summary>
        ///     Creates the report header.
        /// </summary>
        protected override void CreateHeader()
        {
            Write("Information Report", FormatterType.MainHeading);
            Write("Items", FormatterType.Heading);
        }

        //- #CreateCore -//
        /// <summary>
        ///     Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override string CreateCore(object content)
        {
            var data = content as Map;
            if (data != null)
            {
                Write("Item", FormatterType.SubHeading);
                var keyList = data.GetKeyList();
                foreach (var key in keyList)
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