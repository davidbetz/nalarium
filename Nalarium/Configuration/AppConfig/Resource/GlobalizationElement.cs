#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Resource
{
    public class GlobalizationElement : CommentableElement
    {
        //- @Path -//
        [ConfigurationProperty("resourcePath", IsRequired = true, IsKey = true)]
        public string ResourcePath
        {
            get { return (string) this["resourcePath"]; }
            set { this["resourcePath"] = value; }
        }

        //- @AssemblyNamePattern -//
        [ConfigurationProperty("assemblyNamePattern", IsRequired = true)]
        public string AssemblyNamePattern
        {
            get { return (string) this["assemblyNamePattern"]; }
            set { this["assemblyNamePattern"] = value; }
        }

        //- @Enabled -//
        [ConfigurationProperty("enable", DefaultValue = false)]
        public bool Enabled
        {
            get { return (bool) this["enable"]; }
            set { this["enable"] = value; }
        }
    }
}