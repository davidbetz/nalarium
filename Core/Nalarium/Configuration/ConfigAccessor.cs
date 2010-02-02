#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    /// <summary>
    /// Simplifies basic configuration access.
    /// </summary>
    public static class ConfigAccessor
    {
        //- @ApplicationSettings -//
        /// <summary>
        /// Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="defaultValue">Default value to return if the item is not present.</param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(String key, T defaultValue)
        {
            String value = ConfigurationManager.AppSettings[key];
            T returnValue;
            if (String.IsNullOrEmpty(value) && !(typeof(T) == typeof(Boolean)))
            {
                returnValue = defaultValue;
            }
            else
            {
                returnValue = (T)Convert.ChangeType(value, typeof(T));
            }
            return returnValue;
        }
        /// <summary>
        /// Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="isRequired">If true and the data is not present or is blank, an exception (ConfigurationErrorsException) is thrown.</param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(String key, Boolean isRequired)
        {
            String value = ConfigurationManager.AppSettings[key];
            T returnValue;
            if (String.IsNullOrEmpty(value))
            {
                if (isRequired)
                {
                    throw new ConfigurationErrorsException(String.Format(System.Globalization.CultureInfo.CurrentCulture, Nalarium.Globalization.ResourceAccessor.GetString("Config_SettingRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager), key));
                }
                else
                {
                    returnValue = default(T);
                }
            }
            else
            {
                returnValue = (T)Convert.ChangeType(value, typeof(T));
            }
            return returnValue;
        }
        /// <summary>
        /// Enables quick access to appSettings data as a String.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="isRequired">If true and the data is not present or is blank, an exception (ConfigurationErrorsException) is thrown.</param>
        /// <returns>Desired string data.</returns>
        public static String ApplicationSettings(String key, Boolean isRequired)
        {
            return ApplicationSettings<String>(key, isRequired);
        }
        /// <summary>
        /// Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(String key)
        {
            return ApplicationSettings<T>(key, false);
        }
        /// <summary>
        /// Enables quick access to appSettings data as a String.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <returns>Desired string data.</returns>
        public static String ApplicationSettings(String key)
        {
            return ApplicationSettings<String>(key, false);
        }

        //- @ConnectionString -//
        /// <summary>
        /// Enables quick access to connectionString data.
        /// </summary>
        /// <param name="key">Key of connectionString item.</param>
        /// <returns>Connection string of entity</returns>
        public static String ConnectionString(String key)
        {
            return ConnectionString(key, false);
        }
        /// <summary>
        /// Enables quick access to connectionString data.
        /// </summary>
        /// <param name="key">Key of connectionString item.</param>
        /// <param name="isRequired">If true and the data is not present or is blank, an exception (ConfigurationErrorsException) is thrown.</param>
        /// <returns>Connection string of entity; an exception is thrown is not found.</returns>
        public static String ConnectionString(String key, Boolean isRequired)
        {
            ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[key];
            if (isRequired && (cs == null || String.IsNullOrEmpty(cs.ConnectionString)))
            {
                throw new ConfigurationErrorsException(String.Format(System.Globalization.CultureInfo.CurrentCulture, Nalarium.Globalization.ResourceAccessor.GetString("Config_SettingRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager), key));
            }
            if ((cs == null || String.IsNullOrEmpty(cs.ConnectionString)))
            {
                return String.Empty;
            }
            //+
            return cs.ConnectionString;
        }
    }
}