﻿#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Configuration;
//+
namespace Nalarium.Web.Processing.Configuration
{
    public class EndpointCollection : Nalarium.Configuration.CommentableCollection<EndpointElement>
    {
        //- #GetElementKey -//
        protected override Object GetElementKey(ConfigurationElement element)
        {
            EndpointElement endpointElement = (EndpointElement)element;
            //+
            return endpointElement.Selector + ":" + endpointElement.Type + ":" + endpointElement.Text;
        }
    }
}