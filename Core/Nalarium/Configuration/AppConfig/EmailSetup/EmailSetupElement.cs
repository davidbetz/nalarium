#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Configuration;

namespace Nalarium.Configuration.AppConfig.EmailSetup
{
    public class EmailSetupElement : WithParametersElement
    {
        //- @Server -//
        [ConfigurationProperty("server", IsRequired = true)]
        public String Server
        {
            get
            {
                return (String)this["server"];
            }
            set
            {
                this["server"] = value;
            }
        }

        //- @UserName -//
        [ConfigurationProperty("username")]
        public String UserName
        {
            get
            {
                return (String)this["username"];
            }
            set
            {
                this["username"] = value;
            }
        }

        //- @Password -//
        [ConfigurationProperty("password")]
        public String Password
        {
            get
            {
                return (String)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        //- @From -//
        [ConfigurationProperty("from")]
        public String From
        {
            get
            {
                return (String)this["from"];
            }
            set
            {
                this["from"] = value;
            }
        }

        //- @Enabled -//
        [ConfigurationProperty("to")]
        public String To
        {
            get
            {
                return (String)this["to"];
            }
            set
            {
                this["to"] = value;
            }
        }
    }
}