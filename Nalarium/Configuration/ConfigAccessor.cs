using System;
using System.Configuration;
using System.Globalization;
using Nalarium.Globalization;
using Nalarium.Properties;

namespace Nalarium.Configuration
{
    /// <summary>
    ///     Simplifies basic configuration access.
    /// </summary>
    public static class ConfigAccessor
    {
        //- @ApplicationSettings -//
        /// <summary>
        ///     Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="defaultValue">Default value to return if the item is not present.</param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(string key, T defaultValue)
        {
            var value = GetAppSettings(key);
            T returnValue;
            if (string.IsNullOrEmpty(value) && !(typeof (T) == typeof (bool)))
            {
                returnValue = defaultValue;
            }
            else
            {
                returnValue = (T) Convert.ChangeType(value, typeof (T));
            }
            return returnValue;
        }

        /// <summary>
        ///     Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="isRequired">
        ///     If true and the data is not present or is blank, an exception (ConfigurationErrorsException)
        ///     is thrown.
        /// </param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(string key, bool isRequired)
        {
            var value = GetAppSettings(key);
            T returnValue;
            if (string.IsNullOrEmpty(value))
            {
                if (isRequired)
                {
                    throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("Config_SettingRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager), key));
                }
                returnValue = default(T);
            }
            else
            {
                returnValue = (T) Convert.ChangeType(value, typeof (T));
            }
            return returnValue;
        }

        /// <summary>
        ///     Enables quick access to appSettings data as a String.
        /// </summary>
        /// <param name="key">Key of appSettings item.</param>
        /// <param name="isRequired">
        ///     If true and the data is not present or is blank, an exception (ConfigurationErrorsException)
        ///     is thrown.
        /// </param>
        /// <returns>Desired string data.</returns>
        public static string ApplicationSettings(string key, bool isRequired)
        {
            return ApplicationSettings<string>(key, isRequired);
        }

        /// <summary>
        ///     Enables quick access to appSettings data as strongly-typed data.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="key">Key of appSettings item.</param>
        /// <returns>Desired strongly-typed data.</returns>
        public static T ApplicationSettings<T>(string key)
        {
            return ApplicationSettings<T>(key, false);
        }

        /// <summary>
        ///     Enables quick access to appSettings data as a String.
        /// </summary>
        /// <param name="key">Key of appSettings item.</param>
        /// <returns>Desired string data.</returns>
        public static string ApplicationSettings(string key)
        {
            return ApplicationSettings<string>(key, false);
        }

        //- @ConnectionString -//
        /// <summary>
        ///     Enables quick access to connectionString data.
        /// </summary>
        /// <param name="key">Key of connectionString item.</param>
        /// <returns>Connection string of entity</returns>
        public static string ConnectionString(string key)
        {
            return ConnectionString(key, false);
        }

        /// <summary>
        ///     Enables quick access to connectionString data.
        /// </summary>
        /// <param name="key">Key of connectionString item.</param>
        /// <param name="isRequired">
        ///     If true and the data is not present or is blank, an exception (ConfigurationErrorsException)
        ///     is thrown.
        /// </param>
        /// <returns>Connection string of entity; an exception is thrown is not found.</returns>
        public static string ConnectionString(string key, bool isRequired)
        {
            var cs = GetConnectionString(key);
            if (isRequired && (cs == null || string.IsNullOrEmpty(cs)))
            {
                throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, ResourceAccessor.GetString("Config_SettingRequired", AssemblyInfo.AssemblyName, Resource.ResourceManager), key));
            }
            if (cs == null || string.IsNullOrEmpty(cs))
            {
                return string.Empty;
            }
            //+
            return cs;
        }

        private static string GetAppSettings(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
            {
                return string.Empty;
            }
            if (appSetting.StartsWith("{") && appSetting.EndsWith("}"))
            {
                key = appSetting.Substring(1, appSetting.Length - 2);
                appSetting = ConfigurationManager.AppSettings[key];
            }
            return appSetting;
        }

        private static string GetConnectionString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            var csSettings = ConfigurationManager.ConnectionStrings[key];
            var cs = csSettings.ConnectionString;
            if (string.IsNullOrEmpty(cs))
            {
                return string.Empty;
            }
            if (cs.StartsWith("{") && cs.EndsWith("}"))
            {
                key = cs.Substring(1, cs.Length - 2);
                csSettings = ConfigurationManager.ConnectionStrings[key];
                if (string.IsNullOrEmpty(csSettings?.ConnectionString))
                {
                    return string.Empty;
                }
                cs = csSettings.ConnectionString;
            }
            return cs;
        }
    }
}