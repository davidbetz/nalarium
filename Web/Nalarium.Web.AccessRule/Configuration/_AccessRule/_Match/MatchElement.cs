#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Web.AccessRule.Configuration
{
    [System.Diagnostics.DebuggerDisplay("{Usage}, {Value}")]
    public class MatchElement : Nalarium.Configuration.CommentableElement
    {
        //- @Usage -//
        [ConfigurationProperty("usage")]
        public String Usage
        {
            get { return (String)this["usage"]; }
            set { this["usage"] = value; }
        }

        //- @Value -//
        [ConfigurationProperty("value")]
        public String Value
        {
            get { return (String)this["value"]; }
            set { this["value"] = value; }
        }
    }
}