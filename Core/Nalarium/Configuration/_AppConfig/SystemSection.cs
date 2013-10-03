#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System.Configuration;

namespace Nalarium.Configuration
{
    /// <summary>
    /// Provides access to the configuration section.
    /// </summary>
    public class SystemSection : ConfigurationSection
    {
        //- @AppInfo -//
        [ConfigurationProperty("appInfo")]
        public AppInfoElement AppInfo
        {
            get
            {
                return (AppInfoElement)this["appInfo"];
            }
            set
            {
                this["appInfo"] = value;
            }
        }

        //- @EmailSetup -//
        [ConfigurationProperty("emailSetup")]
        public EmailSetupElement EmailSetup
        {
            get
            {
                return (EmailSetupElement)this["emailSetup"];
            }
            set
            {
                this["emailSetup"] = value;
            }
        }

        //- @ReportingElement -//
        [ConfigurationProperty("reporting")]
        public ReportingElement Reporting
        {
            get
            {
                return (ReportingElement)this["reporting"];
            }
            set
            {
                this["reporting"] = value;
            }
        }

        //- @Globalization -//
        [ConfigurationProperty("globalization")]
        public GlobalizationElement Globalization
        {
            get
            {
                return (GlobalizationElement)this["globalization"];
            }
            set
            {
                this["appInfo"] = value;
            }
        }

        //- @Factories -//
        [ConfigurationProperty("factories")]
        [ConfigurationCollection(typeof(FactoryElement), AddItemName = "add")]
        public FactoryCollection Factories
        {
            get
            {
                return (FactoryCollection)this["factories"];
            }
        }

        //- @Objects -//
        [ConfigurationProperty("objects")]
        [ConfigurationCollection(typeof(ObjectElement), AddItemName = "add")]
        public ObjectCollection Objects
        {
            get
            {
                return (ObjectCollection)this["objects"];
            }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static SystemSection GetConfigSection()
        {
            return GetConfigSection<SystemSection>("nalarium/system");
        }
    }
}