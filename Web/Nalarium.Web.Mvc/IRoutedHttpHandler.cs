//+
namespace Nalarium.Web.Mvc
{
    public interface IRoutedHttpHandler : System.Web.IHttpHandler, System.Web.Routing.IRouteHandler
    {
        System.Web.Routing.RequestContext RequestContext { get; set; }
    }
}