#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Object
{
    public class ObjectElement : CommentableElement
    {
        //- @Name -//
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string) this["name"]; }
        }

        //- @Type -//
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string) this["type"]; }
        }

        //- @Value -//
        [ConfigurationProperty("value")]
        public string Value
        {
            get { return (string) this["value"]; }
        }
    }
}