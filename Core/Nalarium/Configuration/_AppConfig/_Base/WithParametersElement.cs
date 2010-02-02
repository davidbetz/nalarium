﻿#region Copyright
//+ Nalarium Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Configuration
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
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
            return this.Parameters.GetValue(name);
        }
    }
}