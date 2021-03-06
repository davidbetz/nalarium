﻿#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Configuration;
using Nalarium.Configuration.AppConfig.AppInfo;
using Nalarium.Configuration.AppConfig.EmailSetup;
using Nalarium.Configuration.AppConfig.Factory;
using Nalarium.Configuration.AppConfig.Object;
using Nalarium.Configuration.AppConfig.Reporting;
using Nalarium.Configuration.AppConfig.Resource;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    ///     Provides access to the configuration section.
    /// </summary>
    public class SystemSection : ConfigurationSection
    {
        //- @AppInfo -//
        [ConfigurationProperty("appInfo")]
        public AppInfoElement AppInfo
        {
            get { return (AppInfoElement) this["appInfo"]; }
            set { this["appInfo"] = value; }
        }

        //- @EmailSetup -//
        [ConfigurationProperty("emailSetup")]
        public EmailSetupElement EmailSetup
        {
            get { return (EmailSetupElement) this["emailSetup"]; }
            set { this["emailSetup"] = value; }
        }

        //- @ReportingElement -//
        [ConfigurationProperty("reporting")]
        public ReportingElement Reporting
        {
            get { return (ReportingElement) this["reporting"]; }
            set { this["reporting"] = value; }
        }

        //- @Globalization -//
        [ConfigurationProperty("globalization")]
        public GlobalizationElement Globalization
        {
            get { return (GlobalizationElement) this["globalization"]; }
            set { this["appInfo"] = value; }
        }

        //- @Factories -//
        [ConfigurationProperty("factories")]
        [ConfigurationCollection(typeof (FactoryElement), AddItemName = "add")]
        public FactoryCollection Factories
        {
            get { return (FactoryCollection) this["factories"]; }
        }

        //- @Objects -//
        [ConfigurationProperty("objects")]
        [ConfigurationCollection(typeof (ObjectElement), AddItemName = "add")]
        public ObjectCollection Objects
        {
            get { return (ObjectCollection) this["objects"]; }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        ///     Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static SystemSection GetConfigSection()
        {
            return GetConfigSection<SystemSection>("nalarium/system");
        }
    }
}