#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System.ComponentModel;
using System.Configuration;
using Nalarium.Configuration.AppConfig.Parameter;

namespace Nalarium.Configuration.AppConfig
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class WithParametersElement : CommentableElement
    {
        //- @Parameters -//
        [ConfigurationProperty("parameters")]
        [ConfigurationCollection(typeof (ParameterCollection), AddItemName = "add")]
        public ParameterCollection Parameters
        {
            get { return (ParameterCollection) this["parameters"]; }
            set { this["parameters"] = value; }
        }

        //- @GetParameterValue -//
        public string GetParameterValue(string name)
        {
            return Parameters.GetValue(name);
        }
    }
}