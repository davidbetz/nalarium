#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    public class ObjectElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
        }

        //- @Type -//
        [ConfigurationProperty("type", IsRequired = true)]
        public String Type
        {
            get
            {
                return (String)this["type"];
            }
        }

        //- @Value -//
        [ConfigurationProperty("value")]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
        }
    }
}