#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Configuration;
using System.Diagnostics;
using Nalarium.Configuration;

namespace Nalarium.Web.AccessRule.Configuration
{
    [DebuggerDisplay("{Name}")]
    public class RuleElement : CommentableElement
    {
        //- @Group -//
        [ConfigurationProperty("group")]
        public String Group
        {
            get
            {
                return (String)this["group"];
            }
            set
            {
                this["group"] = value;
            }
        }

        //- @Matches -//
        [ConfigurationProperty("composite")]
        [ConfigurationCollection(typeof(ParameterElement), AddItemName = "add")]
        public WhenCollection Composite
        {
            get
            {
                return (WhenCollection)this["composite"];
            }
        }

        //- @Action -//
        [ConfigurationProperty("action")]
        public String Action
        {
            get
            {
                return (String)this["action"];
            }
            set
            {
                this["action"] = value;
            }
        }

        //- @Condition -//
        [ConfigurationProperty("condition")]
        public String Condition
        {
            get
            {
                return (String)this["condition"];
            }
            set
            {
                this["condition"] = value;
            }
        }
    }
}