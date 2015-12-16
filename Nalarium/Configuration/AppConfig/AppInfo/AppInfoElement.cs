#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.AppInfo
{
    public class AppInfoElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", DefaultValue = "")]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }
    }
}