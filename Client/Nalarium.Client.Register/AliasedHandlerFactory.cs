using System;
//+
namespace Nalarium.Client.Register
{
    public class HandlerFactory : Nalarium.Web.Processing.HandlerFactory
    {
        //- @CreateHttpHandler -//
        public override System.Web.IHttpHandler CreateHttpHandler(String text)
        {
            switch (text)
            {
                case "clientresourcehandler":
                    return new Nalarium.Client.ClientResourceHandler();
            }
            //+
            return null;
        }
    }
}