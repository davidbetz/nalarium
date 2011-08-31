﻿#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration
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