#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Globalization;

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