#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Globalization;

namespace Nalarium.Reporting.ReportCreator
{
    public class CommonReportCreatorFactory : ReportCreatorFactory
    {
        //- @Create -//
        /// <summary>
        ///     Generates the report.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ReportCreator Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                switch (name.ToLower(CultureInfo.CurrentCulture))
                {
                    case "exception":
                        return new ExceptionReportCreator();
                    case "objectarray":
                        return new ObjectArrayReportCreator();
                    case "map":
                        return new MapReportCreator();
                    case "string":
                        return new StringReportCreator();
                }
            }
            //+
            return null;
        }
    }
}