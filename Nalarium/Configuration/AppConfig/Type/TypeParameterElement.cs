#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.Configuration;

namespace Nalarium.Configuration.AppConfig.Type
{
    public class TypeParameterElement : CommentableElement, IHasPriority
    {
        //- @Value -//
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string) this["type"]; }
            set { this["type"] = value; }
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