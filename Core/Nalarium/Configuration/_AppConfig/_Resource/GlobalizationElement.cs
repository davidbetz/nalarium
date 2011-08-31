#region Copyright

//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration
{
    public class GlobalizationElement : CommentableElement
    {
        //- @Path -//
        [ConfigurationProperty("resourcePath", IsRequired = true, IsKey = true)]
        public String ResourcePath
        {
            get
            {
                return (String)this["resourcePath"];
            }
            set
            {
                this["resourcePath"] = value;
            }
        }

        //- @AssemblyNamePattern -//
        [ConfigurationProperty("assemblyNamePattern", IsRequired = true)]
        public String AssemblyNamePattern
        {
            get
            {
                return (String)this["assemblyNamePattern"];
            }
            set
            {
                this["assemblyNamePattern"] = value;
            }
        }

        //- @Enabled -//
        [ConfigurationProperty("enable", DefaultValue = false)]
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