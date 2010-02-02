﻿#region Copyright
//+ Nalarium Pro 3.0 - Client Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
//+
//+ This file is a part of the Nalarium Suite.
//+ The use and distribution terms for this software are covered by the
//+ Microsoft Permissive License (Ms-PL) which can be found at
//+ http://www.microsoft.com/opensource/licenses.mspx.
#endregion
using System;
using System.Web.Mvc;
//+
namespace Nalarium.Client.Mvc
{
    public static class CssHtmlHelper
    {
        //- @CssInclude -//
        public static String CssInclude(this System.Web.Mvc.HtmlHelper helper, String path)
        {
            TagBuilder link = new TagBuilder("link");
            link.MergeAttribute("type", "text/css");
            link.MergeAttribute("href", new UrlHelper(helper.ViewContext.RequestContext).Content(path));
            link.MergeAttribute("rel", "stylesheet");
            //+
            return link.ToString(TagRenderMode.SelfClosing);
        }
    }
}