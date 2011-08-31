#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration
{
    public class ReporterElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        //- @Creator -//
        [ConfigurationProperty("creator", IsRequired = true)]
        public String Creator
        {
            get
            {
                return (String)this["creator"];
            }
            set
            {
                this["creator"] = value;
            }
        }

        //- @Sender -//
        [ConfigurationProperty("sender", IsRequired = true)]
        public String Sender
        {
            get
            {
                return (String)this["sender"];
            }
            set
            {
                this["sender"] = value;
            }
        }

        //- @Formatter -//
        [ConfigurationProperty("formatter", IsRequired = false, DefaultValue = "wiki")]
        public String Formatter
        {
            get
            {
                return (String)this["formatter"];
            }
            set
            {
                this["formatter"] = value;
            }
        }

        //- @Enabled -//
        [ConfigurationProperty("enable", DefaultValue = true)]
        public Boolean Enabled
        {
            get
            {
                return (Boolean)this["enable"];
            }
            set
            {
                this["enable"] = value;
            }
        }
    }
}