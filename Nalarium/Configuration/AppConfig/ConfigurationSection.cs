#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.ComponentModel;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig
{
    /// <summary>
    ///     Provides access to the configuration section.
    /// </summary>
    public class ConfigurationSection : System.Configuration.ConfigurationSection
    {
        //- @Xmlns -//
        /// <summary>
        ///     Provides the ability to provide an XML namespace.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ConfigurationProperty("xmlns")]
        public string Xmlns
        {
            get { return (string) this["xmlns"]; }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        ///     Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static T GetConfigSection<T>(string location) where T : ConfigurationSection, new()
        {
            if (string.IsNullOrEmpty(location))
            {
                return new T();
            }
            //+
            return (T) ConfigurationManager.GetSection(location) ?? new T();
        }
    }
}