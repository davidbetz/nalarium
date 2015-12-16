using System.Configuration;
using System.Diagnostics;

namespace Nalarium.Configuration.AppConfig.Factory
{
    [DebuggerDisplay("{FactoryType}, {Priority}")]
    public class FactoryElement : WithParameterArrayElement
    {
        //- @FactoryType -//
        [ConfigurationProperty("type", IsRequired = true)]
        public string FactoryType
        {
            get { return (string) this["type"]; }
            set { this["type"] = value; }
        }

        //- @Priority -//
        [ConfigurationProperty("priority", DefaultValue = 5, IsRequired = false)]
        public int Priority
        {
            get { return (int) this["priority"]; }
            set { this["priority"] = value; }
        }

        //- @Enabled -//
        [ConfigurationProperty("enabled", DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool) this["enabled"]; }
            set { this["enabled"] = value; }
        }
    }
}