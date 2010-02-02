#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
//+
namespace Nalarium.Web.Mvc
{
    public abstract class ReusableHttpHandler : Nalarium.Web.ReusableHttpHandler, IRoutedHttpHandler
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