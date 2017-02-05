#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.EmailSetup
{
    public class EmailSetupElement : WithParametersElement
    {
        //- @Server -//
        [ConfigurationProperty("server")]
        public string Server
        {
            get { return (string) this["server"]; }
            set { this["server"] = value; }
        }

        //- @UserName -//
        [ConfigurationProperty("username")]
        public string UserName
        {
            get { return (string) this["username"]; }
            set { this["username"] = value; }
        }

        //- @Password -//
        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string) this["password"]; }
            set { this["password"] = value; }
        }

        //- @From -//
        [ConfigurationProperty("from")]
        public string From
        {
            get { return (string) this["from"]; }
            set { this["from"] = value; }
        }

        //- @Enabled -//
        [ConfigurationProperty("to")]
        public string To
        {
            get { return (string) this["to"]; }
            set { this["to"] = value; }
        }
    }
}