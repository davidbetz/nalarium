#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Parameter
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

        #region IHasPriority Members

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

        #endregion
    }
}