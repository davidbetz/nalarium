#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Web.AccessRule.Configuration
{
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class AliasElement : Nalarium.Configuration.CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name")]
        public String Name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }

        //- @Type -//
        [ConfigurationProperty("type")]
        public String Type
        {
            get { return (String)this["type"]; }
            set { this["type"] = value; }
        }
    }
}