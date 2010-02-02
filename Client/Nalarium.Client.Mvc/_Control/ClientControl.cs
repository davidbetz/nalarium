#region Copyright
//+ Nalarium Pro 3.0 - Client Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
//+
//+ This file is a part of the Nalarium Suite.
//+ The use and distribution terms for this software are covered by the
//+ Microsoft Permissive License (Ms-PL) which can be found at
//+ http://www.microsoft.com/opensource/licenses.mspx.
#endregion
//+
namespace Nalarium.Client.Mvc
{
    public abstract class ClientControl : Nalarium.Web.Mvc.Control
    {
        protected System.Web.Mvc.ViewContext ViewContext { get; set; }

        public ClientHelper Client { get; set; }

        public ClientControl(System.Web.Mvc.ViewContext context)
        {
            ViewContext = context;
            Client = new ClientHelper((context.Controller as IControllerContainer).ClientController);
        }
    }
}