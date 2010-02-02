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
    public abstract class ViewPage<TModel> : System.Web.Mvc.ViewPage<TModel> where TModel : class
    {
        //- #Client -//
        protected ClientHelper Client { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            Client = new ClientHelper((ViewContext.Controller as IControllerContainer).ClientController);
            //+
            base.OnInit(e);
        }
    }   
    public abstract class ViewPage : System.Web.Mvc.ViewPage
    {
        //- #Client -//
        protected ClientHelper Client { get; set; }

        //+
        //- #OnInit -//
        protected override void OnInit(EventArgs e)
        {
            Client = new ClientHelper((ViewContext.Controller as IControllerContainer).ClientController);
            //+
            base.OnInit(e);
        }
    }
}