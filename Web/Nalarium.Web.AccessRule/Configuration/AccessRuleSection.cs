#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System.Configuration;
using ConfigurationSection = Nalarium.Configuration.ConfigurationSection;

namespace Nalarium.Web.AccessRule.Configuration
{
    /// <summary>
    /// Provides access to the configuration section.
    /// </summary>
    public class AccessRuleSection : ConfigurationSection
    {
        //- @Rules -//
        [ConfigurationProperty("rules")]
        [ConfigurationCollection(typeof(RuleElement), AddItemName = "add")]
        public RuleCollection Rules
        {
            get
            {
                return (RuleCollection)this["rules"];
            }
        }

        //- @Aliases -//
        [ConfigurationProperty("aliases")]
        [ConfigurationCollection(typeof(AliasElement), AddItemName = "add")]
        public AliasCollection Aliases
        {
            get
            {
                return (AliasCollection)this["aliases"];
            }
        }

        //+
        //- @GetConfigSection -//
        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <returns>Configuration section</returns>
        public static AccessRuleSection GetConfigSection()
        {
            return GetConfigSection<AccessRuleSection>("nalarium/accessRule");
        }
    }
}