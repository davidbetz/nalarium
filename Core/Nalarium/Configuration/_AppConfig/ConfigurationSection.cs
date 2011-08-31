#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration
{
    /// <summary>
    /// Provides access to the configuration section.
    /// </summary>
    public class ConfigurationSection : System.Configuration.ConfigurationSection
    {
        //- @Xmlns -//
        /// <summary>
        /// Provides the ability to provide an XML namespace.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ConfigurationProperty("xmlns")]
        public String Xmlns
        {
            get
            {
                return (String)this["xmlns"];
            }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static T GetConfigSection<T>(String location) where T : ConfigurationSection, new()
        {
            if (String.IsNullOrEmpty(location))
            {
                return new T();
            }
            //+
            return (T)ConfigurationManager.GetSection(location) ?? new T();
        }
    }
}