#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
//+
namespace Nalarium.Reporting
{
    public class CommonFormatterFactory : FormatterFactory
    {
        //- @Create -//
        /// <summary>
        /// Creates a formatter based on the specified alias
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override Formatter Create(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                switch (name.ToLower(System.Globalization.CultureInfo.CurrentCulture))
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