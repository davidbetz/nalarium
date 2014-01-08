#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
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
        [ConfigurationCollection(typeof(ParameterCollection), AddItemName = "add")]
        public ParameterCollection Parameters
        {
            get
            {
                return (ParameterCollection)this["parameters"];
            }
            set
            {
                this["parameters"] = value;
            }
        }

        //- @GetParameterValue -//
        public String GetParameterValue(String name)
        {
            return Parameters.GetValue(name);
        }
    }
}