using System;
using System.Web;
using System.Web.Routing;
using Nalarium.Activation;

namespace Nalarium.Web.Mvc
{
    public class HandlerRouteHandler : IRouteHandler
    {
        //+
        //- @Ctor -//
        public HandlerRouteHandler(Type httpHandlerType)
        {
            _httpHandlerType = httpHandlerType;
        }

        private Type _httpHandlerType { get; set; }

        //+
        //- @GetHttpHandler -//

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return GetHttpHandler(_httpHandlerType, requestContext);
        }

        #endregion

        //+
        //- @GetHttpHandler -//
        public static IHttpHandler GetHttpHandler<T>(RequestContext requestContext) where T : class
        {
            return GetHttpHandler(typeof(T), requestContext);
        }

        public static IHttpHandler GetHttpHandler(Type httpHandlerType, RequestContext requestContext)
        {
            var handler = ObjectCreator.CreateAs<IHttpHandler>(httpHandlerType);
            var routedHttpHandler = handler as IRoutedHttpHandler;
            if (routedHttpHandler != null)
            {
                routedHttpHandler.RequestContext = requestContext;
            }
            //+
            return handler;
        }
    }
}