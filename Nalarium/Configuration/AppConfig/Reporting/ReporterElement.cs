#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Reporting
{
    public class ReporterElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }

        //- @Creator -//
        [ConfigurationProperty("creator", IsRequired = true)]
        public string Creator
        {
            get { return (string) this["creator"]; }
            set { this["creator"] = value; }
        }

        //- @Sender -//
        [ConfigurationProperty("sender", IsRequired = true)]
        public string Sender
        {
            get { return (string) this["sender"]; }
            set { this["sender"] = value; }
        }

        //- @Formatter -//
        [ConfigurationProperty("formatter", IsRequired = false, DefaultValue = "wiki")]
        public string Formatter
        {
            get { return (string) this["formatter"]; }
            set { this["formatter"] = value; }
        }

        //- @Enabled -//
        [ConfigurationProperty("enable", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool) this["enable"]; }
            set { this["enable"] = value; }
        }
    }
}