using System;
//+
namespace Nalarium.Web.Mvc
{
    public class HandlerRouteHandler : System.Web.Routing.IRouteHandler
    {
        private Type _httpHandlerType { get; set; }

        //+
        //- @Ctor -//
        public HandlerRouteHandler(Type httpHandlerType)
        {
            _httpHandlerType = httpHandlerType;
        }

        //+
        //- @GetHttpHandler -//
        public System.Web.IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            return GetHttpHandler(_httpHandlerType, requestContext);
        }

        //+
        //- @GetHttpHandler -//
        public static System.Web.IHttpHandler GetHttpHandler<T>(System.Web.Routing.RequestContext requestContext) where T : class
        {
            return GetHttpHandler(typeof(T), requestContext);
        }
        public static System.Web.IHttpHandler GetHttpHandler(Type httpHandlerType, System.Web.Routing.RequestContext requestContext)
        {
            System.Web.IHttpHandler handler = Nalarium.Activation.ObjectCreator.CreateAs<System.Web.IHttpHandler>(httpHandlerType);
            IRoutedHttpHandler routedHttpHandler = handler as IRoutedHttpHandler;
            if (routedHttpHandler != null)
            {
                routedHttpHandler.RequestContext = requestContext;
            }
            //+
            return handler;
        }
    }
}