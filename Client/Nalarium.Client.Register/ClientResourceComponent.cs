//+
using Nalarium.Client.Configuration;
//+
namespace Nalarium.Client.Register
{
    public class ClientResourceComponent : Nalarium.Web.Processing.Component
    {
        //- @Register -//
        public override void Register()
        {
            AddFactory(Nalarium.Web.Processing.Data.FactoryData.Create("Nalarium.Client.Register.HandlerFactory, Nalarium.Client.Register"));
            AddEndpoint(Nalarium.Web.Processing.Data.EndpointData.Create(Nalarium.Web.SelectorType.Contains, ClientSection.GetConfigSection().ResourceHandlerPath + "?d=", "ClientResourceHandler"));
        }
    }
}