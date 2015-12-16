#region Copyright

//+ Copyright © David Betz 2007-2015

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Parameter
{
    public class ParameterElement : CommentableElement, IHasPriority
    {
        //- @Name -//
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return (string) this["name"]; }
        }

        //- @Value -//
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string) this["value"]; }
        }

        //- @Priority -//

        #region IHasPriority Members

        [ConfigurationProperty("priority", DefaultValue = 5, IsRequired = false)]
        public int Priority
        {
            get { return (int) this["priority"]; }
            set { this["priority"] = value; }
        }

        #endregion
    }
}