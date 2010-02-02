#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright � Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
using Nalarium.Reporting;
//+
namespace Nalarium.Web.Reporting
{
    public class ReportCreatorFactory : Nalarium.Reporting.ReportCreatorFactory
    {
        //- @Create -//
        /// <summary>
        /// Creates a specified report creator from the aliased name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override ReportCreator Create(String name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                switch (name.ToLower(System.Globalization.CultureInfo.CurrentCulture))
                {
                    case "httpcontext":
                        return new HttpContextReportCreator();
                }
            }
            //+
            return null;
        }
    }
}