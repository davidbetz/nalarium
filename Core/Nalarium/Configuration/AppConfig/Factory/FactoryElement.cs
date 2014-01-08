using System;
using System.Configuration;
using System.Diagnostics;

namespace Nalarium.Configuration.AppConfig.Factory
{
    [DebuggerDisplay("{FactoryType}, {Priority}")]
    public class FactoryElement : WithParameterArrayElement
    {
        //- @FactoryType -//
        [ConfigurationProperty("type", IsRequired = true)]
        public String FactoryType
        {
            get
            {
                return (String)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        //- @Priority -//
        [ConfigurationProperty("priority", DefaultValue = 5, IsRequired = false)]
        public Int32 Priority
        {
            get
            {
                return (Int32)this["priority"];
            }
            set
            {
                this["priority"] = value;
            }
        }

        //- @Enabled -//
        [ConfigurationProperty("enabled", DefaultValue = true, IsRequired = false)]
        public Boolean Enabled
        {
            get
            {
                return (Boolean)this["enabled"];
            }
            set
            {
                this["enabled"] = value;
            }
        }
    }
}