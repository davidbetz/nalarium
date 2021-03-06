#region Copyright

//+ Copyright � David Betz 2007-2017

#endregion

using System;
using System.Reflection;
using Nalarium.Configuration.AppConfig;

namespace Nalarium.Activation
{
    /// <summary>
    ///     Used to load an assembly.
    /// </summary>
    public static class AssemblyLoader
    {
        //- @Load -//
        /// <summary>
        ///     Loads and assembly and reports errors through David Betz 2007-2017 object injection reporting.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns>Assembly object.</returns>
        public static Assembly Load(string assemblyName)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception ex)
            {
                if (ObjectInjectionReportController.Reporter.Initialized)
                {
                    var map = new Map();
                    map.Add("App Name", SystemSection.GetConfigSection().AppInfo.Name);
                    map.Add("Section", "Resource Injector");
                    map.Add("AssemblyName", assemblyName);
                    map.Add("Message", ex.Message);
                    map.Add("Exception Type", ex.GetType().FullName);
                    //+
                    ObjectInjectionReportController.Reporter.AddMap(map);
                    ObjectInjectionReportController.Reporter.Send(true);
                    ObjectInjectionReportController.Reporter.ReportCreator.Clear();
                }
            }
            //+
            return null;
        }

        //- @GetShortName -//
        /// <summary>
        ///     Obtains the short name of an assembly.
        /// </summary>
        /// <param name="assemblyName">Name of assembly.</param>
        /// <returns>Short name of the assembly.</returns>
        public static string GetShortName(string assemblyName)
        {
            var commaIndex = assemblyName.IndexOf(",");
            if (commaIndex > -1)
            {
                return assemblyName.Substring(0, commaIndex);
            }
            //+
            return assemblyName;
        }
    }
}