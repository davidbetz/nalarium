﻿#region Copyright
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
    public abstract class Controller : System.Web.Mvc.Controller, IControllerContainer
    {
        public ClientController ClientController { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //+
            ClientController = new ClientController();
        }
    }
}