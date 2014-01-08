#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Configuration;
using System.Diagnostics;
using Nalarium.Configuration;
using Nalarium.Configuration.AppConfig;

namespace Nalarium.Web.AccessRule.Configuration
{
    [DebuggerDisplay("{Usage}, {Value}")]
    public class MatchElement : CommentableElement
    {
        //- @Usage -//
        [ConfigurationProperty("usage")]
        public String Usage
        {
            get
            {
                return (String)this["usage"];
            }
            set
            {
                this["usage"] = value;
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
            set
            {
                this["value"] = value;
            }
        }
    }
}