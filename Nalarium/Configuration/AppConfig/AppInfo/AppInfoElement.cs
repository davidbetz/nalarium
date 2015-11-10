#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig.AppInfo
{
    public class AppInfoElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", DefaultValue = "")]
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
    }
}