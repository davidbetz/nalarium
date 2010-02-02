#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
using System.Web.Mvc;
//+
namespace Nalarium.Web.Mvc
{
    /// <summary>
    /// Represents an HTML span element
    /// </summary>
    public class Span : Nalarium.Web.Mvc.WrappingControl
    {
        protected Span()
        {
        }

        public static Span Create()
        {
            return new Span().ContainerType(Nalarium.Web.HtmlElement.Span) as Span;
        }
    }
}