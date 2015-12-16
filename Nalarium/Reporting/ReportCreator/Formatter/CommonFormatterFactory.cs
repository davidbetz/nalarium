#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Globalization;

namespace Nalarium.Reporting.ReportCreator.Formatter
{
    public class CommonFormatterFactory : FormatterFactory
    {
        //- @Create -//
        /// <summary>
        ///     Creates a formatter based on the specified alias
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override Formatter Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                switch (name.ToLower(CultureInfo.CurrentCulture))
                {
                    case "wiki":
                        return new WikiFormatter();
                    case "html":
                        return new HtmlFormatter();
                }
            }
            //+
            return null;
        }
    }
}