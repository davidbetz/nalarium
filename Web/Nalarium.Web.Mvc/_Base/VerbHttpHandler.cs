#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
using Nalarium.Reflection;
//+
namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Used to handle specific HTTP verbs.
    /// </summary>
    public abstract class VerbHttpHandler : Nalarium.Web.VerbHttpHandler, IRoutedHttpHandler
    {
        //- @RequestContext -//
        public System.Web.Routing.RequestContext RequestContext { get; set; }

        //+
        //- @GetHttpHandler -//
        public System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            RequestContext = requestContext;
            //+
            return this;
        }
    }
}