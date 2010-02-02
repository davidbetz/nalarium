#region Copyright
//+ Nalarium Pro 3.0 - Client Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
//+
//+ This file is a part of the Nalarium Suite.
//+ The use and distribution terms for this software are covered by the
//+ Microsoft Permissive License (Ms-PL) which can be found at
//+ http://www.microsoft.com/opensource/licenses.mspx.
#endregion
using System;
//+
namespace Nalarium.Client.Mvc
{
    public class ViewMasterPage : System.Web.Mvc.ViewMasterPage
    {
        //- #Client -//
        protected ClientHelper Client { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            IControllerContainer container = ViewContext.Controller as IControllerContainer;
            if (container == null)
            {
                throw new InvalidOperationException("Controller must implement IControllerContainer.");
            }
            Client = new ClientHelper(container.ClientController);
            //+
            base.OnInit(e);
        }
    }
}