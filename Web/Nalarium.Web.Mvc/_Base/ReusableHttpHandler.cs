#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System.Web;
using System.Web.Routing;

namespace Nalarium.Web.Mvc
{
    public abstract class ReusableHttpHandler : Web.ReusableHttpHandler, IRoutedHttpHandler
    {
        //- @RequestContext -//

        #region IRoutedHttpHandler Members

        public RequestContext RequestContext { get; set; }

        //+
        //- @GetHttpHandler -//
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            RequestContext = requestContext;
            //+
            return this;
        }

        #endregion
    }
}