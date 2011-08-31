//+

using System.Web;
using System.Web.Routing;

namespace Nalarium.Web.Mvc
{
    public interface IRoutedHttpHandler : IHttpHandler, IRouteHandler
    {
        RequestContext RequestContext { get; set; }
    }
}