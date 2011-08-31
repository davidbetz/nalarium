#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System.Web;
using System.Web.Routing;

namespace Nalarium.Web.Mvc
{
    public abstract class HttpHandler : Web.HttpHandler, IRoutedHttpHandler
    {
        //- @RequestContext -//

        #region IRoutedHttpHandler Members

        public RequestContext RequestContext { get; set; }

        //+
        //- @GetHttpHandler -//
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return HandlerRouteHandler.GetHttpHandler(GetType(), requestContext);
        }

        #endregion
    }
}