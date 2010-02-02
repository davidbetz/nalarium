#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    public class ParameterElement : CommentableElement, IHasPriority
    {
        //- @Name -//
        [ConfigurationProperty("name")]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
        }

        //- @Value -//
        [ConfigurationProperty("value", IsRequired = true)]
        public String Value
        {
            get
            {
                return (String)this["value"];
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
    }
}